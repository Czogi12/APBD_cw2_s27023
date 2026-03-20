using System.Text.RegularExpressions;

namespace APBD_cw2_project_s27023.cli.commands.arguments;

public class StringArgument(string name, bool required, string? regexpPattern) : CommandArgument<string>(name, required)
{
    private string? RegexPattern { get; } = regexpPattern;

    public override bool IsValid(string arg)
    {
        if (string.IsNullOrEmpty(arg)) return false;
        if (RegexPattern is null) return true;
        return Regex.IsMatch(arg, RegexPattern);
    }

    protected override string ParseTyped(string arg)
    {
        return arg;
    }

    protected override string StringifiedType()
    {
        return "string";
    }

    public override string ToString()
    {
        return
            $"{(Required ? '<' : '[')}{Name}:{StringifiedType()}{(regexpPattern is not null ? $"\\{{{RegexPattern}\\}}" : "")}{(Required ? '>' : ']')}";
    }
}