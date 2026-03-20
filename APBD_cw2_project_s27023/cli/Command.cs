namespace APBD_cw2_project_s27023.cli;

public abstract class Command(string[] variants)
{
    public string CommandName => Variants[0];
    private string[] Variants { get; } = variants;

    public bool CommandMatches(string command)
    {
        return Variants.Any(variant => variant == command);
    }

    public abstract void Execute(string[] args);
}