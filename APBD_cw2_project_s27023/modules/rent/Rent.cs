using APBD_cw2_project_s27023.exceptions;
using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.modules.rent;

public class Rent
{
    private DateTime? _realEnd = null;
    public Rent (Equipment equipment, DateTime startDate, DateTime plannedEndDate)
    {
        if (startDate > plannedEndDate)
        {
            throw new ArgumentException("Start date cannot be after planned date and end date");
        }

        Start = startDate;
        End = plannedEndDate;
        Equipment = equipment;
    }

    public Rent(Equipment equipment, DateTime plannedEndDate) : this(equipment, DateTime.Now, plannedEndDate)
    {
    }

    public Equipment Equipment { get; }
    public DateTime Start { get; }
    public DateTime End { get; }
    public DateTime? RealEnd
    {
        get => _realEnd;
        set
        {
            if (_realEnd is not null)
            {
                throw new RendEndDateOverrideException();
            }

            _realEnd = value;
        }
    }

    public bool IsRented()
    {
        return RealEnd.HasValue;
    }
    
    // TODO: implement getRentHours, getHoursExceeded for payment calculations      
}