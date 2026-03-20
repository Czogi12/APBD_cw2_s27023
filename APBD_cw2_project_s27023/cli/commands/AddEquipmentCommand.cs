using System.Drawing;
using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.modules.equipment;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli.commands;

public class AddEquipmentCommand() : Command(["add-equipment", "ae"],
    [
        new StringArgument("type", true,
            $"({string.Join("|", Enum.GetNames(typeof(EquipmentType)).Select(name => name.ToLower()))})")
    ],
    "Adds new equipment with given type and data.")
{
    protected override void ExecuteCommand(string[] args)
    {
        var dataArguments = new List<ICommandArgument>();
        var equipmentType = Enum.Parse<EquipmentType>(args[0], true);
        switch (equipmentType)
        {
            case EquipmentType.Laptop:
                dataArguments.Add(new FloatArgument("Screen size in inches", true));
                dataArguments.Add(new FloatArgument("Battery watt hours", true));
                break;
            case EquipmentType.LaserPointer:
                dataArguments.Add(new IntArgument("Red value(0-255)", true, 0, 255));
                dataArguments.Add(new IntArgument("Green value(0-255)", true, 0, 255));
                dataArguments.Add(new IntArgument("Blue value(0-255)", true, 0, 255));
                dataArguments.Add(new FloatArgument("Range in meters", true));
                break;
            case EquipmentType.Projector:
                dataArguments.Add(new IntArgument("Brightness in lumens", true, 0, null));
                dataArguments.Add(new FloatArgument("Throw distance in meters", true));
                break;
            default:
                throw new NotImplementedException($"EquipmentType {args[0]} creation not implemented!");
        }

        var dataArgs = new List<string>();

        foreach (var argument in dataArguments)
        {
            var fulfilled = false;
            do
            {
                Console.Write($"Provide {argument}: ");
                var line = Console.ReadLine()?.TrimEnd();
                if (line is null || argument.IsValid(line)) continue;
                dataArgs.Add(line);
                fulfilled = true;
            } while (!fulfilled);
        }

        switch (equipmentType)
        {
            case EquipmentType.Laptop:
                EquipmentService.Instance.Add(new LaptopEquipment(Equipment.GetNextId(),
                    float.Parse(dataArgs[0]), float.Parse(dataArgs[1])));
                break;
            case EquipmentType.LaserPointer:
                var color = Color.FromArgb(int.Parse(dataArgs[0]), int.Parse(dataArgs[1]), int.Parse(dataArgs[2]));
                EquipmentService.Instance.Add(new LaserPointerEquipment(Equipment.GetNextId(), color,
                    float.Parse(dataArgs[3])
                ));
                break;
            case EquipmentType.Projector:
                EquipmentService.Instance.Add(new ProjectorEquipment(Equipment.GetNextId(),
                    int.Parse(dataArgs[0]), float.Parse(dataArgs[1])
                ));
                break;
            default:
                throw new NotImplementedException($"EquipmentType {args[0]} creation not implemented!");
        }
    }
}