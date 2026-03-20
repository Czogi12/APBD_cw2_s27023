namespace APBD_cw2_project_s27023.cli.commands.arguments;

// AI suggested workaround for `?` generic wildcard
public interface ICommandArgument
{
    string Name { get; }
    bool Required { get; }

    public bool IsValid(string arg);
    public object? Parse(string arg);
}