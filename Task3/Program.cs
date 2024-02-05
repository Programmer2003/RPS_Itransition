using System.Linq;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Commands.Exit("U must use more than 1 argument...");
            }

            if (args.Distinct().Count() != args.Length)
            {
                Commands.Exit("Wrong arguments (they must be different)...");
            }

            if (args.Length % 2 == 0)
            {
                Commands.Exit("The number of arguments must be odd...");
            }

            Menu menu = new Menu(args);
            menu.GameStart();

            Commands.Exit();

        }
    }
}
