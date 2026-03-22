using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.availability;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowRaportCommand(IUserService userService, IEquipmentService equipmentService, IRentService rentService, IAvailabilityService availabilityService) : Command(["show-raport" ,"raport"], [], "Displays raport")
{
    protected override void ExecuteCommand(string[] args)
    {
        PrintCountableService("Users", userService);
        PrintCountableService("Equipment", equipmentService);
    }
    
    private static void PrintCountableService<T>(string mainName, ICountableService<T> countableService) where T : struct, Enum
    {
        Console.WriteLine($"{mainName}: {countableService.Count()}");
        foreach (var type in Enum.GetValues<T>())
        {
            Console.WriteLine($"\t{type}: {countableService.Count(type)}");
        }
    }
}