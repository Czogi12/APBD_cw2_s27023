using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.modules.user;
using APBD_cw2_project_s27023.ropositories;

namespace APBD_cw2_project_s27023.services.user;

public class UserService()
    : PersistableCachableService<long, User>("users"), IUserService
{
    public override User Get(long id)
    {
        return GetOrDefault(id) ?? throw new ArgumentException("User not found.");
    }

    public int Count()
    {
        return GetAll().Count;
    }

    public int Count(UserType userType)
    {
        return GetAll().Count(x => x.Type == userType);
    }
}