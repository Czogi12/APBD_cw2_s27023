namespace APBD_cw2_project_s27023.cli.commands.arguments;

public class LongArgument(string name, bool required, long? min, long? max) : CommandArgument<long>(name, required)
{
    private long Min => min ?? long.MinValue;
    private long Max => max ?? long.MaxValue;

    public override bool IsValid(string arg)
    {
        var val = 0l;
        try
        {
            val = long.Parse(arg);
        }
        catch (Exception e)
        {
            return false;
        }

        if (val < Min || val > Max) return false;

        return true;
    }

    protected override long ParseTyped(string arg)
    {
        return int.Parse(arg);
    }

    protected override string StringifiedType()
    {
        return "long";
    }
}