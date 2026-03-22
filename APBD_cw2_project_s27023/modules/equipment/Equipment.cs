using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public abstract class Equipment : Identifiable<long>
{
    private static long _maxId;

    protected Equipment(long id, string name) : base(id)
    {
        if (_maxId < id) _maxId = id;
        Name = name;
    }

    // Required field
    public string Name { get; }

    // Required field
    public abstract PowerSource PowerSource { get; }

    public abstract EquipmentType Type { get; }

    public abstract float GetHourlyPrice();

    public static long GetNextId()
    {
        return _maxId + 1;
    }
}