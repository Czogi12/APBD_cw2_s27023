using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services;

public class UserService
{
    private readonly List<User> _users = [];

    private UserService()
    {
    }

    public static UserService Instance { get; } = new();

    public void Add(User user)
    {
        if (_users.Contains(user) || Get(user.Id) != null) return;
        _users.Add(user);
    }

    public void Remove(int userId)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);

        if (user is null) return;

        _users.Remove(user);
    }

    public User? Get(long id)
    {
        return _users.Find(u => u.Id == id);
    }
}