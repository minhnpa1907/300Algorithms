// Author: minhnpa1907@gmail.com

namespace NPAM.Algorithms.Logging;

internal static class Logger
{
    public static string FuncName { get; set; } = string.Empty;

    public static void Logging(string message)
    {
        Console.WriteLine($"MINH-CONSOLE: {FuncName} - {message}");
    }

    public static void LoggingStart()
    {
        Console.WriteLine("\n---------------------------");
        Logging("Start");
    }

    public static void LoggingStop(params object?[]? arg)
    {
        LoggingStop(arg != null ? string.Join(", ", arg) : string.Empty);
    }

    public static void LoggingStop(string output)
    {
        Console.WriteLine($"{FuncName}: {output}");
        Logging($"Stop");
        Console.WriteLine("---------------------------\n");
    }
}
