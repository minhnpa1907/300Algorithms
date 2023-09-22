namespace Algorithms
{
    internal class Logging
    {
        public static void LoggingStart(string func)
        {
            Console.WriteLine("\n---------------------------");
            System.Console.WriteLine($"MINH-CONSOLE: {func} - Start");
        }

        public static void LoggingStop(string func, string output)
        {
            Console.WriteLine($"{func}: {output}");

            System.Console.WriteLine($"MINH-CONSOLE: {func} - Stop");
            Console.WriteLine("---------------------------\n");
        }
    }
}
