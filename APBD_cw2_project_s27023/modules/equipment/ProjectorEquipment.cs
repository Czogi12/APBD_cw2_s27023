using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public class ProjectorEquipment(long id, string name, bool isRented, int lumenBrightness, float throwDistanceMeters)
    : Equipment(id, name, isRented)
{
    public override PowerSource PowerSource => PowerSource.SOCKET;
    public override EquipmentType Type => EquipmentType.PROJECTOR;

    public int LumenBrightness { get; } = lumenBrightness;
    public float ThrowDistanceMeters { get; } = throwDistanceMeters;
}