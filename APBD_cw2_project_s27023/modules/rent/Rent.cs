using APBD_cw2_project_s27023.exceptions;
using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.modules.rent;

public class Rent : Identifiable
{
    private static long _maxId;

    private DateTime? _realEnd;
    public bool IsPaidOff = false;

    public Rent(long id, Equipment equipment, User user, DateTime startDate, DateTime plannedEndDate) : base(id)
    {
        if (startDate > plannedEndDate)
            throw new ArgumentException("Start date cannot be after planned date and end date");

        Start = startDate;
        End = plannedEndDate;
        Equipment = equipment;
        User = user;

        if (id > _maxId) _maxId = id;
    }

    public Rent(Equipment equipment, User user, DateTime plannedEndDate) : this(GetNextId(), equipment, user,
        DateTime.Now,
        plannedEndDate)
    {
    }

    public Equipment Equipment { get; }
    public User User { get; }
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateTime? RealEnd
    {
        get => _realEnd;
        set
        {
            if (_realEnd is not null) throw new RendEndDateOverrideException();

            _realEnd = value;
        }
    }

    public bool IsRented()
    {
        return !RealEnd.HasValue;
    }

    private int GetRentHours()
    {
        if (RealEnd is null) throw new RentNotEndedException();

        return (int)(End - RealEnd.Value).TotalHours;
    }

    private bool WasHeldTooLong()
    {
        return !IsRented() && End < RealEnd;
    }

    private float GetPriceMultiplier()
    {
        return WasHeldTooLong() ? 1.2f : 1f;
    }

    public float GetPrice()
    {
        return GetPriceMultiplier() * GetRentHours() * Equipment.GetHourlyPrice();
    }

    public static long GetNextId()
    {
        return _maxId + 1;
    }
}