using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services;

public class EquipmentService : ServiceWithCache<long, Equipment>, IEquipmentService
{
    public override Equipment Get(long id)
    {
        return GetOrDefault(id) ?? throw new ArgumentException("Equipment not found.");
    }
}