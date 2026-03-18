using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.equipment;

public abstract class Equipment : Identifiable
{
    private static long _maxId = 1;

    protected Equipment(long id, string name, bool isRented) : base(id)
    {
        if (_maxId < id) _maxId = id;
        Name = name;
        IsRented = isRented;
    }

    // Required field
    public string Name { get; }

    // Required field
    public abstract PowerSource PowerSource { get; }

    public abstract EquipmentType Type { get; }

    public bool IsRented { get; set; }

    public static long GetNextId()
    {
        return _maxId + 1;
    }
}