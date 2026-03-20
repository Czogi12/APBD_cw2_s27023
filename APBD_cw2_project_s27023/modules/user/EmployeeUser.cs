using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.user;

public class EmployeeUser(long id, string firstName, string lastName) : User(id, firstName, lastName)
{
    public override UserType Type => UserType.Employee;

    public override int GetMaxRentNumber()
    {
        return 5;
    }

    public override string ToString()
    {
        return $"Employee[id={Id}, firstName={FirstName}, lastName={LastName}]";
    }
}