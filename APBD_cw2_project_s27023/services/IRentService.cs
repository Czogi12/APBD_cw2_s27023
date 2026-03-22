using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.rent;

namespace APBD_cw2_project_s27023.services;

public interface IRentService : IService<long, Rent>
{
    Rent ReturnEquipment(long userId, long equipmentId);
    void RentEquipment(long userId, long equipmentId, int parse);
    Rent? FindActiveRentByEquipment(Equipment equipment);
}