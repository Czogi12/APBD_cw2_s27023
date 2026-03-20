namespace APBD_cw2_project_s27023.cli.commands.arguments;

public abstract class CommandArgument<T>(string name, bool required) : ICommandArgument
{
    public string Name { get; } = name;
    public bool Required { get; } = required;

    public abstract bool IsValid(string arg);

    object? ICommandArgument.Parse(string arg)
    {
        return ParseTyped(arg);
    }

    protected abstract T ParseTyped(string arg);
}