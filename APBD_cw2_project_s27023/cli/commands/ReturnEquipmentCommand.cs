using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class ReturnEquipmentCommand() : Command(["return-equipment", "return"],
    [
        new LongArgument("user", true, null, null),
        new LongArgument("equipment", true, null, null)
    ],
    "Returns equipment by given user.")
{
    protected override void ExecuteCommand(string[] args)
    {
        try
        {
            var userId = long.Parse(args[0]);
            var equipmentId = long.Parse(args[1]);
            var rent = RentService.Instance.ReturnEquipment(
                userId, equipmentId
            );
            var user = UserService.Instance.Get(userId);
            Console.WriteLine(
                $"{user} successfully returned {EquipmentService.Instance.Get(equipmentId)}.");
            Console.WriteLine($"{user} ows {rent.GetPrice()}PLN for this rent");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}