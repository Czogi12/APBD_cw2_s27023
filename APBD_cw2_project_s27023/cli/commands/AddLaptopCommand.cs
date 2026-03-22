using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.factory;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class AddLaptopCommand(IEquipmentService equipmentService) : Command(["add-laptop"], [
    new FloatArgument("screen-size-inches", true),
    new FloatArgument("batter-wh", true)
], "Adds new laptop")
{
    protected override void ExecuteCommand(string[] args)
    {
        var laptop = EquipmentFactory.CreateLaptopEquipment(float.Parse(args[0]), float.Parse(args[1]));
        equipmentService.Add(laptop);
        Console.WriteLine($"Succesfully created and added {laptop}");
    }
}