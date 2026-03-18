using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services;

public class UserService
{
    private List<User> _users = [];

    private UserService()
    {
    }

    public static UserService Instance { get; } = new();

    public void Add(User user)
    {
        _users.Add(user);
    }
    
    public User? Get(int id)
    {
        return _users.Find(u => u.Id == id);
    }
}