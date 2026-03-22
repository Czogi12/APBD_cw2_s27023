using System.Drawing;
using APBD_cw2_project_s27023.modules.equipment;

namespace APBD_cw2_project_s27023.factory;

public static class EquipmentFactory
{
    public static LaptopEquipment CreateLaptopEquipment(float screenSizeInInches, float batteryWattHours)
    {
        return new LaptopEquipment(Equipment.GetNextId(), screenSizeInInches, batteryWattHours);
    }

    public static LaserPointerEquipment CreateLaserPointerEquipment(byte r, byte g, byte b, float rangeInMeters)
    {
        var color = Color.FromArgb(r, g, b);
        return new LaserPointerEquipment(Equipment.GetNextId(), color, rangeInMeters);
    }

    public static ProjectorEquipment CreateProjectorEquipment(int lumenBrightness, float throwDistanceMeters)
    {
        return new ProjectorEquipment(Equipment.GetNextId(), lumenBrightness, throwDistanceMeters);
    }
}