namespace APBD_cw2_project_s27023.cli.commands;

public class ClearCommand() : Command(["clear", "cls", "c"],
    [], "Clears console.")
{
    protected override void ExecuteCommand(string[] args)
    {
        Console.Clear();
    }
}