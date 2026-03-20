using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services;

public class UserServiceWithCache : ServiceWithCache<long, User>
{
    public static UserServiceWithCache Instance { get; } = new();

    public void Add(User user)
    {
        Add(user.Id, user);
    }
}