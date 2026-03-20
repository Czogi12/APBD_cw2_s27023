using APBD_cw2_project_s27023.modules.rent;

namespace APBD_cw2_project_s27023.services;

public class RentService : ServiceWithCache<long, Rent>
{
    public RentService Instance { get; } = new();
}