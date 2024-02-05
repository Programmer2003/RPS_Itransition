using BetterConsoleTables;
using System;
using System.Collections.Generic;


namespace Task3
{
    static class Commands
    {
        public static void ShowTable(string[] Moves)
        {
            Table table = new Table("v PC\\User");
            foreach (var move in Moves)
            {
                table.AddColumn(move);
            }
            int n = Moves.Length;
            for (var i = 0; i < n; i++)
            {
                List<string> row = new List<string>() { Moves[i] };
                for (var j = 0; j < n; j++)
                {
                    row.Add(Game.GameResult(j, i, n, true));
                }
                object[] args = row.ToArray();
                table.AddRow(args);
            }

            table.Config = TableConfiguration.MySql();

            Console.Write(table.ToString());
        }

        public static void Exit(string message = "Press any button...")
        {
            Console.Write(message);
            Console.ReadKey();
            System.Environment.Exit(1);
        }
    }
}
