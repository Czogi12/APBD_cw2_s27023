using APBD_cw2_project_s27023.cli;

namespace APBD_cw2_project_s27023;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Any(arg => arg == "-c" || arg == "--console")) new Cli();
    }
}