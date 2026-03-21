using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services;

public class UserService : ServiceWithCache<long, User>
{
    public void Add(User user)
    {
        Add(user.Id, user);
    }
}