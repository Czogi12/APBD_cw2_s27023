using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.factory;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class AddProjectorCommand(IEquipmentService equipmentService) : Command(["add-projector"], [
    new IntArgument("lumens", true, 0, null),
    new FloatArgument("meters-range", true)
], "Adds new projector")
{
    protected override void ExecuteCommand(string[] args)
    {
        var projector = EquipmentFactory.CreateProjectorEquipment(int.Parse(args[0]), float.Parse(args[1]));
        equipmentService.Add(projector);
        Console.WriteLine($"Succesfully created and added {projector}");
    }
}