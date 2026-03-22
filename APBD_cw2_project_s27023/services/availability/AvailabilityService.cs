using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.servicing;

namespace APBD_cw2_project_s27023.services.availability;

public class AvailabilityService(IRentService rentService, IServicingService servicingService) : IAvailabilityService
{
    public bool IsAvailable(Equipment equipment)
    {
        return rentService.FindActiveRentByEquipment(equipment) is null &&
               servicingService.FindActiveServicingOfEquipment(equipment) is null;
    }
}