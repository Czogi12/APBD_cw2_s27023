using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.services.availability;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowRaportCommand(IUserService userService, IEquipmentService equipmentService, IRentService rentService, IAvailabilityService availabilityService) : Command(["show-raport" ,"raport"], [], "Displays raport")
{
    protected override void ExecuteCommand(string[] args)
    {
        Console.WriteLine($"Users: {userService.Count()}");
        foreach (var type in  Enum.GetValues<UserType>()) {
            Console.WriteLine($"\t{type.ToString()}: {userService.Count(type)}");
        }
        
        Console.WriteLine($"Equipment: {equipmentService.Count()}");
        foreach (var type in  Enum.GetValues<EquipmentType>()) {
            Console.WriteLine($"\t{type.ToString()}: {userService.Count(type)}");
        }
    }
}