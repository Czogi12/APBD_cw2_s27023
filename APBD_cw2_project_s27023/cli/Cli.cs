using APBD_cw2_project_s27023.cli.commands;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli;

public class Cli
{
    private readonly EquipmentService equipmentService;
    private readonly RentService rentService;
    private readonly UserService userService;

    public Cli(UserService userService, EquipmentService equipmentService, RentService rentService)
    {
        this.userService = userService;
        this.equipmentService = equipmentService;
        this.rentService = rentService;
        InitiateCommands();
        InitiateScanner();
    }

    private List<Command> Commands { get; } = [];

    private void InitiateCommands()
    {
        var help = new HelpCommand(this);
        Commands.Add(help);
        Commands.Add(new ClearCommand());
        Commands.Add(new AddUserCommand(userService));
        Commands.Add(new AddEquipmentCommand());
        Commands.Add(new ShowUsersCommand());
        Commands.Add(new ShowEquipmentCommand());
        Commands.Add(new RentEquipmentCommand());
        Commands.Add(new ReturnEquipmentCommand(userService, equipmentService, rentService));

        help.Execute([]);
    }

    private void InitiateScanner()
    {
        string? line;
        while ((line = Console.ReadLine()) != null)
        {
            var words = line.Split(' ');
            if (words.Length < 1) continue;
            var commandText = words[0];
            var args = words.Length > 1 ? words.Skip(1).ToArray() : [];

            var executed = false;

            foreach (var command in Commands)
            {
                if (!command.CommandMatches(commandText)) continue;
                executed = true;
                command.Execute(args);
                break;
            }

            if (!executed) Console.WriteLine($"Command \"{commandText}\" not found.");
        }
    }

    public void DisplayHelp()
    {
        foreach (var command in Commands)
        {
            command.Print();
            Console.WriteLine();
        }
    }
}