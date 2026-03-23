using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.modules.quotable.servicing;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services.servicing;

public class ServicingService() : PersistableCachableService<long, Servicing>("servicing"), IServicingService
{
    public override Servicing Get(long id)
    {
        return GetOrDefault(id) ?? throw new ArgumentException("No servicing found for id " + id);
    }

    public List<Servicing> FindUnpaidServicingOfUser(User user)
    {
        return GetAll().FindAll(servicing =>
            servicing.Rent.User == user && servicing.IsServiced() && !servicing.IsPaidOff);
    }

    public Servicing? FindActiveServicingOfEquipment(Equipment equipment)
    {
        return GetAll().Find(servicing => !servicing.IsServiced() && servicing.Rent.Equipment.Id == equipment.Id);
    }
}