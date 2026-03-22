using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.user;

public abstract class User : Identifiable<long>
{
    private static long _maxId;

    protected User(long id, string firstName, string lastName) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        if (_maxId < id) _maxId = id;
    }

    public abstract UserType Type { get; }

    public string FirstName { get; }
    public string LastName { get; }

    public static long GetNextId()
    {
        return _maxId + 1;
    }

    public abstract int GetMaxRentNumber();
}