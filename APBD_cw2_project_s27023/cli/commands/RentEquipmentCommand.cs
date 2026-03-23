using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.rent;

namespace APBD_cw2_project_s27023.cli.commands;

public class RentEquipmentCommand(IRentService rentService) : Command(["rent-equipment", "re", "rent", "r"],
    [
        new LongArgument("user", true, null, null),
        new LongArgument("equipment", true, null, null),
        new IntArgument("hours", true, 1, 12)
    ],
    "Rents equipment to given user.")
{
    protected override void ExecuteCommand(string[] args)
    {
        try
        {
            var userId = long.Parse(args[0]);
            var equipmentId = long.Parse(args[1]);
            rentService.RentEquipment(
                userId, equipmentId,
                int.Parse(args[2])
            );
            Console.WriteLine(
                $"Successfully rented equipment.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}