using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.modules.quotable.servicing;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.servicing;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli.commands;

public class ReturnEquipmentCommand(
    IUserService userService,
    IEquipmentService equipmentService,
    IRentService rentService,
    IServicingService servicingService)
    : Command(
        ["return-equipment", "return"],
        [
            new LongArgument("user", true, null, null),
            new LongArgument("equipment", true, null, null),
            new StringArgument("damage-description", false, null)
        ],
        "Returns equipment by given user.")
{
    protected override void ExecuteCommand(string[] args)
    {
        try
        {
            var userId = long.Parse(args[0]);
            var equipmentId = long.Parse(args[1]);
            var rent = rentService.ReturnEquipment(
                userId, equipmentId
            );
            var user = userService.Get(userId);
            Console.WriteLine(
                $"{user} successfully returned {equipmentService.Get(equipmentId)}.");
            Console.WriteLine($"{user} ows {rent.GetPrice()}PLN for this rent");

            if (args.Length > 2) servicingService.Add(new Servicing(string.Join(" ", args.Skip(2)), rent));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}