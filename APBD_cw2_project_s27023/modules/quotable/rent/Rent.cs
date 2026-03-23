using System.Text.Json.Serialization;
using APBD_cw2_project_s27023.exceptions;
using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.modules.quotable.rent;

public class Rent : Quotable
{
    private static readonly float RentOverduePenalty = .2f;

    private static long _maxId;

    private DateTime? _realEnd;

    [JsonConstructor]
    public Rent(long id, Equipment equipment, User user, DateTime start, DateTime end) : base(id)
    {
        if (start > end)
            throw new ArgumentException("Start date cannot be after planned date and end date");

        Start = start;
        End = end;
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
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

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

        return Math.Max((int)(RealEnd.Value - Start).TotalHours, 0) + 1;
    }

    public bool WasHeldTooLong()
    {
        return !IsRented() && End < RealEnd;
    }

    private float GetPenaltyPrice()
    {
        if (WasHeldTooLong()) return GetRentHours() * RentOverduePenalty * Equipment.GetHourlyPrice();

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

    public void FalsifyLateRentForTest()
    {
        End = Start;
        Start = Start.Subtract(TimeSpan.FromHours(1));
    }
}