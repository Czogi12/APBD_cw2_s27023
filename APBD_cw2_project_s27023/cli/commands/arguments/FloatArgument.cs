namespace APBD_cw2_project_s27023.cli.commands.arguments;

public class FloatArgument(string name, bool required) : CommandArgument<float>(name, required)
{
    public override bool IsValid(string arg)
    {
        try
        {
            float.Parse(arg);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }

    protected override float ParseTyped(string arg)
    {
        return int.Parse(arg);
    }
}