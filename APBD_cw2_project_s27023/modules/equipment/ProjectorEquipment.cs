using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public class ProjectorEquipment(long id, int lumenBrightness, float throwDistanceMeters)
    : Equipment(id, "PRO-" + id)
{
    public override PowerSource PowerSource => PowerSource.SOCKET;
    public override EquipmentType Type => EquipmentType.Projector;

    public int LumenBrightness { get; } = lumenBrightness;
    public float ThrowDistanceMeters { get; } = throwDistanceMeters;

    public override string ToString()
    {
        return
            $"Projector[id={Id}, name=\"{Name}\", limenBrightness={LumenBrightness}, throwDistanceMeters={ThrowDistanceMeters}]";
    }
}