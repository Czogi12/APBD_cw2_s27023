using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.rent;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services;

public class RentService : ServiceWithCache<long, Rent>
{
    public static RentService Instance { get; } = new();

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

    public bool IsEquipmentRented(Equipment equipment)
    {
        return FindActiveRentByEquipment(equipment) is not null;
    }

    public void RentEquipment(Equipment equipment, User user, int hours)
    {
        var rent = new Rent(equipment, user, DateTime.Now.AddHours(hours));
        Add(rent.Id, rent);
    }

    public void ReturnEquipment(Equipment equipment)
    {
        var rent = FindActiveRentByEquipment(equipment);
        if (rent is not null) rent.RealEnd = DateTime.Now;
    }

    public void PayOffRent(Rent rent)
    {
        rent.IsPaidOff = true;
    }
}