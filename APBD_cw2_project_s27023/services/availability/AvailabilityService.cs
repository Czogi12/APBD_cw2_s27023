using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.services.rent;

namespace APBD_cw2_project_s27023.services.availability;

public class AvailabilityService(IRentService rentService) : IAvailabilityService
{
    public bool IsAvailable(Equipment equipment)
    {
        // TODO: add Servicing/Broken status
        return rentService.FindActiveRentByEquipment(equipment) is null;
    }
}