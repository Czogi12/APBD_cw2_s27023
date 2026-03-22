using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.quotable.servicing;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services.servicing;

public interface IServicingService : IService<long, Servicing>
{
    public List<Servicing> FindUnpaidServicingOfUser(User user);
    public Servicing? FindActiveServicingOfEquipment(Equipment equipment);
}