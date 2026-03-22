namespace APBD_cw2_project_s27023.cli.commands.arguments;

public class BoolArgument(string name, bool required) : CommandArgument<bool>(name, required)
{
    public override bool IsValid(string arg)
    {
        return arg == "1" || arg == "0" || arg == "true" || arg == "yes" || arg == "y" || arg == "false" ||
               arg == "no" || arg == "n";
    }

    protected override bool ParseTyped(string arg)
    {
        return arg == "1" || arg == "true" || arg == "yes" || arg == "y";
    }

    protected override string StringifiedType()
    {
        return "bool";
    }
}