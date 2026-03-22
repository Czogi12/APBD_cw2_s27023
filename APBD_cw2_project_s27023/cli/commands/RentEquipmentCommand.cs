using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class RentEquipmentCommand(RentService rentService) : Command(["rent-equipment", "re", "rent", "r"],
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
                $"{rentService.Get(userId)} successfully rented {rentService.Get(equipmentId)}.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}