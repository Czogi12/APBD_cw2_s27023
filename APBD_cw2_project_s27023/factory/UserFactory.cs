using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.factory;

public class UserFactory
{
    public static User? CreateUser(string type, string firstName, string lastName)
    {
        // Source - https://stackoverflow.com/a/21561708
        // Posted by Paweł Bejger
        // Retrieved 2026-03-20, License - CC BY-SA 3.0
        UserType? userType = (UserType)Enum.Parse(typeof(UserType), type);
        
        return userType switch
        {
            UserType.Student => new StudentUser(User.GetNextId(), firstName, lastName),
            UserType.Employee => new EmployeeUser(User.GetNextId(), firstName, lastName),
            _ => null
        };
    }
}