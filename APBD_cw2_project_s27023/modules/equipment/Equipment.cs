using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public abstract class Equipment(EquipmentType equipmentType)
{
    public EquipmentType Type { get; set; }
}