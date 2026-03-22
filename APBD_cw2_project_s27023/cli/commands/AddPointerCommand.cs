using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.factory;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class AddPointerCommand(IEquipmentService equipmentService) : Command(["add-pointer"], [
    new IntArgument("red", true, 0, 255),
    new IntArgument("green", true, 0, 255),
    new IntArgument("blue", true, 0, 255),
    new FloatArgument("meters-range", true)
], "Adds new laser pointer")
{
    protected override void ExecuteCommand(string[] args)
    {
        var laserPointer = EquipmentFactory.CreateLaserPointerEquipment(byte.Parse(args[0]), byte.Parse(args[1]),
            byte.Parse(args[2]), float.Parse(args[3]));
        equipmentService.Add(laserPointer);
        Console.WriteLine($"Successfully created and added {laserPointer}");
    }
}