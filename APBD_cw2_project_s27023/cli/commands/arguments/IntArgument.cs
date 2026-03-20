namespace APBD_cw2_project_s27023.cli.commands.arguments;

public class IntArgument(string name, bool required, int? min, int? max) : CommandArgument<int>(name, required)
{
    private int Min => min ?? int.MinValue;
    private int Max => max ?? int.MaxValue;

    public override bool IsValid(string arg)
    {
        var val = 0;
        try
        {
            val = int.Parse(arg);
        }
        catch (Exception e)
        {
            return false;
        }

        if (val < Min || val > Max) return false;

        return true;
    }

    protected override int ParseTyped(string arg)
    {
        return int.Parse(arg);
    }
}