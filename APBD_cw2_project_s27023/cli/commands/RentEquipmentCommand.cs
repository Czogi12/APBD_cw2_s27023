using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class RentEquipmentCommand() : Command(["rent-equipment", "re", "rent", "r"],
    [
        new LongArgument("user", true, null, null),
        new LongArgument("equipment", true, null, null),
        new IntArgument("hours", true, 1, 12)
    ],
    "Rents equipment to given user.")
{
    protected override void ExecuteCommand(string[] args)
    {
        var user = UserService.Instance.Get(long.Parse(args[0]));

        if (user is null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        var equipment = EquipmentService.Instance.Get(long.Parse(args[1]));

        if (equipment is null) Console.WriteLine("Equipment not found.");

        // TODO: implement the rest after implementing IsRented method in RentService      
    }
}