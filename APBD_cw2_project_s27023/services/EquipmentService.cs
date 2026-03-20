using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services;

public class EquipmentService : ServiceWithCache<long, Equipment>
{
    public static EquipmentService Instance { get; } = new();

    public void Add(Equipment e)
    {
        Add(e.Id, e);
    }
}