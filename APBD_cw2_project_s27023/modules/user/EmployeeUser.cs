using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.user;

public class EmployeeUser(long id, string firstName, string lastName) : User(id, firstName, lastName)
{
    public override UserType Type => UserType.EMPLOYEE;

    public override int GetMaxRentNumber()
    {
        return 5;
    }
}