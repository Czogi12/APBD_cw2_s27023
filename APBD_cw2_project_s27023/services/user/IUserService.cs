using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.modules.user;

namespace APBD_cw2_project_s27023.services.user;

public interface IUserService : IService<long, User>
{
    int Count();
    int Count(UserType userType);
}