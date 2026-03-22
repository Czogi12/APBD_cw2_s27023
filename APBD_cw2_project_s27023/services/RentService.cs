using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.rent;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services;

public class RentService(IUserService userService, IEquipmentService equipmentService)
    : ServiceWithCache<long, Rent>, IRentService
{
    public void RentEquipment(long equipmentId, long userId, int hours)
    {
        var user = userService.Get(userId);

        if (user is null) throw new ArgumentException("User not found.");
        if (!UserIsUnderRentingLimit(user)) throw new ArgumentException("User exceeds renting limits.");

        var equipment = equipmentService.Get(equipmentId);

        if (equipment is null) throw new ArgumentException("Equipment not found.");
        if (IsEquipmentRented(equipment)) throw new ArgumentException("Equipment is already rented.");

        var rent = new Rent(equipment, user, DateTime.Now.AddHours(hours));
        Add(rent);
    }

    public Rent ReturnEquipment(long equipmentId, long userId)
    {
        var equipment = equipmentService.Get(equipmentId);

        if (equipment is null) throw new ArgumentException("Equipment not found.");
        if (!IsEquipmentRented(equipment))
            throw new ArgumentException($"{equipment} is not rented thus cannot be returned.");

        var user = userService.Get(userId);

        if (user is null) throw new ArgumentException("User not found.");
        var rent = FindActiveRentByEquipment(equipment);
        // should never be called
        if (rent is null) throw new ArgumentException("Rent not found.");
        if (FindActiveRentByEquipment(equipment)!.User != user)
            throw new ArgumentException($"{user} has not rented {equipment}.");

        rent.RealEnd = DateTime.Now;
        return rent;
    }

    public Rent? FindActiveRentByEquipment(Equipment equipment)
    {
        return GetAll().FirstOrDefault(r => r.Equipment == equipment && r.IsRented());
    }

    public List<Rent> FindRentsOfUser(User user)
    {
        return GetAll().FindAll(rent => rent.User == user);
    }

    public List<Rent> FindActiveRentsOfUser(User user)
    {
        return FindRentsOfUser(user).FindAll(rent => rent.IsRented());
    }

    public List<Equipment> FindAllAvailableEquipment()
    {
        return equipmentService.GetAll()
            .FindAll(e => !IsEquipmentRented(e));
    }

    public bool IsEquipmentRented(Equipment equipment)
    {
        return FindActiveRentByEquipment(equipment) is not null;
    }

    public bool UserIsUnderRentingLimit(User user)
    {
        return FindRentsOfUser(user).Count < user.GetMaxRentNumber();
    }

    public void PayOffRent(Rent rent)
    {
        rent.IsPaidOff = true;
    }
}