using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.services.equipment;

public interface IEquipmentService : IService<long, Equipment>, ICountableService<EquipmentType>
{
}