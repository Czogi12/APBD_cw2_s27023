using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services;

public class AvailabilityService(IRentService rentService) : IAvailabilityService
{
    public bool IsAvailable(Equipment equipment)
    {
        return rentService.FindActiveRentByEquipment(equipment) is null;
    }
}