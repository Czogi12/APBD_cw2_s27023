using APBD_cw2_project_s27023.cli.commands.arguments;

namespace APBD_cw2_project_s27023.cli.commands;

public abstract class Command(string[] variants, ICommandArgument[] arguments, string helpText)
{
    private string CommandName => Variants[0];
    private string[] Variants { get; } = variants;
    private ICommandArgument[] Arguments { get; } = arguments;
    private string HelpText { get; } = helpText;

    public bool CommandMatches(string command)
    {
        return Variants.Any(variant => variant == command);
    }

    public void Execute(string[] args)
    {
        if (args.Length < Arguments.Count(argument => argument.Required))
        {
            Console.WriteLine("Invalid number of arguments");
            Print();
            return;
        }

        for (var i = 0; i < args.Length; i++)
        {
            var argumentValidator = Arguments[i];
            if (!argumentValidator.IsValid(args[i]))
            {
                Console.WriteLine($"Invalid argument: {argumentValidator.Name}");
                Print();
                return;
            }
        }

        ExecuteCommand(args);
    }

    private void PrintUsage()
    {
        Console.Write($"Usage: {CommandName}");
        if (Arguments.Length > 0)
            Console.Write(
                $" {string.Join(" ", Arguments.Select(argument => $"{(argument.Required ? '<' : '[')}{argument.Name}{(argument.Required ? '>' : ']')}"))}");
        Console.WriteLine();
    }

    private void PrintHelp()
    {
        Console.WriteLine($"{CommandName} - {HelpText}");
    }

    public void Print()
    {
        PrintHelp();
        PrintUsage();
    }

    protected abstract void ExecuteCommand(string[] args);
}