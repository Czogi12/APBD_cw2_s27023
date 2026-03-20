using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.modules.user;

public class StudentUser(long id, string firstName, string lastName) : User(id, firstName, lastName)
{
    public override UserType Type => UserType.Student;

    public override int GetMaxRentNumber()
    {
        return 2;
    }

    public override string ToString()
    {
        return $"Student[id={Id}, firstName={FirstName}, lastName={LastName}]";
    }
}