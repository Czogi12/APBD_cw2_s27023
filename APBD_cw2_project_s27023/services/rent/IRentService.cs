using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.quotable.rent;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services.rent;

public interface IRentService : IService<long, Rent>
{
    Rent ReturnEquipment(long userId, long equipmentId);
    void RentEquipment(long userId, long equipmentId, int parse);
    Rent? FindActiveRentByEquipment(Equipment equipment);
    List<Rent> FindActiveRentsOfUser(User user);
    List<Rent> GetAllStale();
}