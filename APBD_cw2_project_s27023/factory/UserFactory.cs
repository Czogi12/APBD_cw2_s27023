using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.factory;

public class UserFactory
{
    public static User? CreateUser(string type, string firstName, string lastName)
    {
        return type switch
        {
            "student" => new StudentUser(User.GetNextId(), firstName, lastName),
            "employee" => new EmployeeUser(User.GetNextId(), firstName, lastName),
            _ => null
        };
    }
}