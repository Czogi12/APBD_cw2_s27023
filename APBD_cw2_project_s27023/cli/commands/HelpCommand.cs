namespace APBD_cw2_project_s27023.cli.commands;

public class HelpCommand(Cli cli) : Command(["help", "h"],
    [], "Displays help message.")
{
    private Cli cli { get; } = cli;

    protected override void ExecuteCommand(string[] args)
    {
        Console.WriteLine("This is equipment renting management program.");
        cli.DisplayHelp();
    }
}