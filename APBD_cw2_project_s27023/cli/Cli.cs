using APBD_cw2_project_s27023.cli.commands;
using APBD_cw2_project_s27023.services.availability;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.servicing;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli;

public class Cli
{
    private readonly IAvailabilityService availabilityService;
    private readonly IEquipmentService equipmentService;
    private readonly IRentService rentService;
    private readonly IServicingService servicingService;
    private readonly IUserService userService;

    public Cli(IUserService userService, IEquipmentService equipmentService, IRentService rentService,
        IAvailabilityService availabilityService, IServicingService servicingService, bool executeTests)
    {
        this.userService = userService;
        this.equipmentService = equipmentService;
        this.rentService = rentService;
        this.availabilityService = availabilityService;
        this.servicingService = servicingService;
        InitiateCommands();
        Commands.Find(command => command.CommandMatches("help"))?.Execute([]);

        if (executeTests)
        {
            // Adding equipment
            Commands.Find(command => command.CommandMatches("add-laptop"))?.Execute(["100", "200"]);
            Commands.Find(command => command.CommandMatches("add-projector"))?.Execute(["100", "200"]);
            Commands.Find(command => command.CommandMatches("add-pointer"))?.Execute(["0", "0", "255", "10"]);
            
            // Adding users
            Commands.Find(command => command.CommandMatches("au"))?.Execute(["student", "Asd", "Dsa"]);
            Commands.Find(command => command.CommandMatches("au"))?.Execute(["employee", "Fgh", "Hgf"]);
            
            // Rent equipment
            Commands.Find(command => command.CommandMatches("rent"))?.Execute(["1", "1", "10"]);
            // Rent same equipment
            Commands.Find(command => command.CommandMatches("rent"))?.Execute(["1", "1", "10"]);
            // Returning   
            Commands.Find(command => command.CommandMatches("return"))?.Execute(["1", "1"]);
            
            // Rent again
            Commands.Find(command => command.CommandMatches("rent"))?.Execute(["1", "1", "10"]);
            var rent = rentService.FindActiveRentByEquipment(equipmentService.Get(1));
            rent?.FalsifyLateRentForTest();
            Commands.Find(command => command.CommandMatches("return"))?.Execute(["1", "1"]);
            
            Commands.Find(command => command.CommandMatches("raport"))?.Execute(["count"]);
            Commands.Find(command => command.CommandMatches("raport"))?.Execute(["stale"]);
            Commands.Find(command => command.CommandMatches("raport"))?.Execute(["earnings"]);
        }

        InitiateScanner();
    }

    private List<Command> Commands { get; } = [];

    private void InitiateCommands()
    {
        Commands.Add(new HelpCommand(this));
        Commands.Add(new ClearCommand());
        Commands.Add(new AddUserCommand(userService));
        Commands.Add(new AddLaptopCommand(equipmentService));
        Commands.Add(new AddPointerCommand(equipmentService));
        Commands.Add(new AddProjectorCommand(equipmentService));
        Commands.Add(new ShowUsersCommand(userService));
        Commands.Add(new ShowEquipmentCommand(equipmentService, availabilityService));
        Commands.Add(new RentEquipmentCommand(rentService));
        Commands.Add(new ReturnEquipmentCommand(userService, equipmentService, rentService, servicingService));
        Commands.Add(new ShowUsersRentsCommand(userService, rentService));
        Commands.Add(new ShowStaleRentsCommand(rentService));
        Commands.Add(new ShowRaportCommand(userService, equipmentService ,rentService, availabilityService, servicingService));
        
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