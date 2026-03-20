using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.enums;

namespace APBD_cw2_project_s27023.cli.commands;

public class AddEquipmentCommand() : Command(["add-equipment", "ae"],
    [
        new StringArgument("type", true,
            $"({string.Join("|", Enum.GetNames(typeof(EquipmentType)).Select(name => name.ToLower()))})"),
        new StringArgument("...data", false, null)
    ],
    "Adds new equipment with given type and data.")
{
    protected override void ExecuteCommand(string[] args)
    {
        throw new NotImplementedException();
    }
}