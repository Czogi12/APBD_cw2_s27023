using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services;

public class EquipmentServiceWithCache : ServiceWithCache<long, Equipment>
{
    public void Add(Equipment e)
    {
        Add(e.Id, e);
    }
}