using APBD_cw2_project_s27023.cli.commands.arguments;
using APBD_cw2_project_s27023.enums;
using APBD_cw2_project_s27023.services;
using APBD_cw2_project_s27023.services.availability;
using APBD_cw2_project_s27023.services.equipment;
using APBD_cw2_project_s27023.services.rent;
using APBD_cw2_project_s27023.services.servicing;
using APBD_cw2_project_s27023.services.user;

namespace APBD_cw2_project_s27023.cli.commands;

public class ShowRaportCommand(IUserService userService, IEquipmentService equipmentService, IRentService rentService,
    IAvailabilityService availabilityService, ServicingService servicingService) : Command(["show-raport" ,"raport"], [
new StringArgument("type", false, "(count|stale|earnings)")
], "Displays raport")
{
    protected override void ExecuteCommand(string[] args)
    {
        string raportType = args.Length > 0 ? args[0] : "count";

        switch (raportType)
        {
            case "count":
                PrintCountableService("Users", userService);
                PrintCountableService("Equipment", equipmentService);
                
                Console.WriteLine($"Available equipment: {equipmentService.GetAll().FindAll(availabilityService.IsAvailable)}");
                Console.WriteLine($"Unavailable equipment: {equipmentService.GetAll().FindAll(eq => !availabilityService.IsAvailable(eq))}");
                
                Console.WriteLine($"Rents: {rentService.GetAll().Count}");
                Console.WriteLine($"\tActive: {rentService.GetAll().FindAll(rent => rent.IsRented()).Count}");
                Console.WriteLine($"\t\tStale: {rentService.GetAll().FindAll(rent => rent.IsRented() && rent.WasHeldTooLong()).Count}");
                Console.WriteLine($"\t\tNon-Stale: {rentService.GetAll().FindAll(rent => rent.IsRented() && !rent.WasHeldTooLong()).Count}");
                Console.WriteLine($"\tReturned: {rentService.GetAll().FindAll(rent => !rent.IsRented()).Count}");
                
                Console.WriteLine($"Services: {servicingService.GetAll().Count}");
                Console.WriteLine($"\tDone: {servicingService.GetAll().FindAll(servicing => !servicing.IsServiced()).Count}");
                Console.WriteLine($"\tIn progress: {servicingService.GetAll().FindAll(servicing => !servicing.IsServiced()).Count}");
                Console.WriteLine($"\t\tPaid-off: {servicingService.GetAll().FindAll(servicing => servicing.IsServiced() && servicing.IsPaidOff).Count}");
                Console.WriteLine($"\t\tWaiting for payment: {servicingService.GetAll().FindAll(servicing => !servicing.IsServiced() && !servicing.IsPaidOff).Count}");
                break;
            case "stale":
                Console.WriteLine("Stale rents.");
                foreach (var rent in rentService.GetAllStale())
                {
                    Console.WriteLine(rent);
                }
                break;
            case "earnings":
                var rentCollected = 0f;
                var rentAwaiting = 0f;

                foreach (var rent in rentService.GetAll().Where(rent => !rent.IsRented()))
                {
                    if (rent.IsPaidOff)
                    {
                        rentCollected += rent.GetPrice();
                    }
                    else
                    {
                        rentAwaiting += rent.GetPrice();
                    }
                }
                Console.WriteLine($"Rent");
                Console.WriteLine($"\tCollected: {rentCollected}");
                Console.WriteLine($"\tAwaiting: {rentAwaiting}");
                Console.WriteLine($"\tProfit after collection: {rentAwaiting + rentCollected}");
                
                var serviceCollected = 0f;
                var serviceAwaiting = 0f;

                foreach (var servicing in servicingService.GetAll().Where(servicing => servicing.IsServiced()))
                {
                    if (servicing.IsPaidOff)
                    {
                        serviceCollected += servicing.GetPrice();
                    }
                    else
                    {
                        serviceAwaiting += servicing.GetPrice();
                    }
                }
                Console.WriteLine($"Servicing");
                Console.WriteLine($"\tCollected: {serviceCollected}");
                Console.WriteLine($"\tAwaiting: {serviceAwaiting}");
                
                break;
        }
    }
    
    private static void PrintCountableService<T>(string mainName, ICountableService<T> countableService) where T : struct, Enum
    {
        Console.WriteLine($"{mainName}: {countableService.Count()}");
        foreach (var type in Enum.GetValues<T>())
        {
            Console.WriteLine($"\t{type}: {countableService.Count(type)}");
        }
    }
}