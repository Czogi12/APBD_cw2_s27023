using System.Drawing;
using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public class LaserPointerEquipment(long id, string name, bool isRented, Color color, float rangeInMeters)
    : Equipment(id, name, isRented)
{
    public override PowerSource PowerSource => PowerSource.BATTERIES;
    public override EquipmentType Type => EquipmentType.LASER_POINTER;

    public Color Color { get; } = color;

    public float RangeInMeters { get; } = rangeInMeters;
}