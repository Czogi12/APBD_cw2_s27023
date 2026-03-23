using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.quotable.rent;
using APBD_cw2_project_s27023.modules.user;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.services.rent;

public class RentService(IUserService userService, IEquipmentService equipmentService)
    : PersistableCachableService<long, Rent>("rent"), IRentService
{
    public void RentEquipment(long equipmentId, long userId, int hours)
    {
        var user = userService.Get(userId);
        if (!UserIsUnderRentingLimit(user)) throw new ArgumentException("User exceeds renting limits.");

        var equipment = equipmentService.Get(equipmentId);
        if (IsEquipmentRented(equipment)) throw new ArgumentException("Equipment is already rented.");

        var rent = new Rent(equipment, user, DateTime.Now.AddHours(hours));
        Add(rent);
    }

    public Rent ReturnEquipment(long equipmentId, long userId)
    {
        var equipment = equipmentService.Get(equipmentId);

        if (!IsEquipmentRented(equipment))
            throw new ArgumentException($"{equipment} is not rented thus cannot be returned.");

        var user = userService.Get(userId);

        var rent = FindActiveRentByEquipment(equipment);

        if (rent?.User != user)
            throw new ArgumentException($"{user} has not rented {equipment}.");

        rent.RealEnd = DateTime.Now;
        return rent;
    }

    public Rent? FindActiveRentByEquipment(Equipment equipment)
    {
        return GetAll().FirstOrDefault(r => r.Equipment == equipment && r.IsRented());
    }

    public override Rent Get(long id)
    {
        var rent = GetOrDefault(id);
        return rent ?? throw new ArgumentException("Rent not found.");
    }

    public List<Rent> FindRentsOfUser(User user)
    {
        return GetAll().FindAll(rent => rent.User == user);
    }

    public List<Rent> FindActiveRentsOfUser(User user)
    {
        return FindRentsOfUser(user).FindAll(rent => rent.IsRented());
    }

    public List<Rent> GetAllStale()
    {
        var now = DateTime.Now;
        return GetAll().FindAll(rent => rent.IsRented() && rent.End < now);
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
        return FindActiveRentsOfUser(user).Count < user.GetMaxRentNumber();
    }

    public void PayOffRent(Rent rent)
    {
        rent.IsPaidOff = true;
    }
}