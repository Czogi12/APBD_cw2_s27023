using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services.equipment;

public class EquipmentService() : PersistableCachableService<long, Equipment>("equipment"), IEquipmentService
{
    public override Equipment Get(long id)
    {
        return GetOrDefault(id) ?? throw new ArgumentException("Equipment not found.");
    }

    public int Count(EquipmentType e)
    {
        return GetAll().Count(x => x.Type == e);
    }
}