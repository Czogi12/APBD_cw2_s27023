using APBD_cw2_project_s27023.cli.commands;
using APBD_cw2_project_s27023.services;

namespace APBD_cw2_project_s27023.cli;

public class Cli
{
    private readonly IAvailabilityService availabilityService;
    private readonly IEquipmentService equipmentService;
    private readonly IRentService rentService;
    private readonly IUserService userService;

    public Cli(IUserService userService, IEquipmentService equipmentService, IRentService rentService,
        IAvailabilityService availabilityService)
    {
        this.userService = userService;
        this.equipmentService = equipmentService;
        this.rentService = rentService;
        this.availabilityService = availabilityService;
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
        Commands.Add(new AddEquipmentCommand(equipmentService));
        Commands.Add(new ShowUsersCommand(userService));
        Commands.Add(new ShowEquipmentCommand(equipmentService, availabilityService));
        Commands.Add(new RentEquipmentCommand(rentService));
        Commands.Add(new ReturnEquipmentCommand(userService, equipmentService, rentService));

        help.Execute([]);
    }

    private void InitiateScanner()
    {
        while (Console.ReadLine() is { } line)
        {
            var words = line.Split(' ');
            if (words.Length < 1) continue;
            var commandText = words[0];
            var args = words.Length > 1 ? words.Skip(1).ToArray() : [];

            var command = Commands.FirstOrDefault(command => command.CommandMatches(commandText));

            if (command is null) Console.WriteLine($"Command \"{commandText}\" not found.");
            else command.Execute(args);
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