using System.Drawing;
using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public class LaserPointerEquipment(long id, bool isRented, Color color, float rangeInMeters)
    : Equipment(id, "LAS-" + id, isRented)
{
    public override PowerSource PowerSource => PowerSource.BATTERIES;
    public override EquipmentType Type => EquipmentType.LaserPointer;

    public Color Color { get; } = color;

    public float RangeInMeters { get; } = rangeInMeters;
}