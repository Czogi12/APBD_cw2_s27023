using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services.availability;

public interface IAvailabilityService
{
    bool IsAvailable(Equipment equipment);
}