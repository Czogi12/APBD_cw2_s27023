using APBD_cw2_project_s27023.exceptions;
using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.modules.quotable.rent;

public class Rent : Quotable
{
    private static readonly float RentOverduePenalty = .2f;

    private static long _maxId;

    private DateTime? _realEnd;

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
    private DateTime Start { get; }
    private DateTime End { get; }

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

        return (int)(Start - RealEnd.Value).TotalHours + 1;
    }

    private bool WasHeldTooLong()
    {
        return !IsRented() && End < RealEnd;
    }

    private float GetPenaltyPrice()
    {
        if (WasHeldTooLong()) return GetRentHours() * RentOverduePenalty;

        return 0;
    }

    public override float GetPrice()
    {
        return GetPenaltyPrice() + GetRentHours() * Equipment.GetHourlyPrice();
    }

    private static long GetNextId()
    {
        return _maxId + 1;
    }
}