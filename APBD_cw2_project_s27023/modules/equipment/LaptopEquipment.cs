using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public class LaptopEquipment(
    long id,
    float screenSizeInches,
    float batteryWattHours)
    : Equipment(id, "LAP-" + id)
{
    public override PowerSource PowerSource => PowerSource.MIXED;
    public override EquipmentType Type => EquipmentType.Laptop;

    public float ScreenSizeInches { get; } = screenSizeInches;
    public float BatteryWattHours { get; } = batteryWattHours;
}