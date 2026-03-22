using APBD_cw2_project_s27023.cli;
using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.availability;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023;

public class Program
{
    public static void Main(string[] args)
    {
        var userService = new UserService();
        var equipmentService = new EquipmentService();
        var rentService = new RentService(userService, equipmentService);
        var availabilityService = new AvailabilityService(rentService);

        if (args.Any(arg => arg == "--console"))
            new Cli(userService, equipmentService, rentService, availabilityService);
    }
}