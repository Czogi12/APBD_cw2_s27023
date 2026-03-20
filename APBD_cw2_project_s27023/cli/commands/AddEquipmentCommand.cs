using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.enums;

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

        // TODO: finish when EquipmentService is ready
        switch (equipmentType)
        {
            case EquipmentType.Laptop:

                break;
            case EquipmentType.LaserPointer:
                break;
            case EquipmentType.Projector:
                break;
            default:
                throw new NotImplementedException($"EquipmentType {args[0]} creation not implemented!");
        }
    }
}