using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    internal class Menu
    {
        private static string CheckLink = "https://cryptotools.net/hmac";
        private static string Method = "SHA-256";

        public string[] Moves { get; private set; }
        public HmacGenerator hmac;
        public Menu(string[] moves)
        {
            Moves = moves;
        }

        public void GameStart()
        {
            hmac = new HmacGenerator(Moves);
            while (true)
            {
                Console.WriteLine($"HMAC: {hmac.GetHash()}");
                Console.WriteLine("Available moves:");
                int i = 1;
                foreach (var move in Moves)
                {
                    Console.WriteLine($"{i++} - {move}");
                }
                Console.WriteLine("0 - Exit");
                Console.WriteLine("? - help");
                Input();
            }
        }

        private void Input()
        {
            Console.Write("Enter your move: ");
            string choice = Console.ReadLine();
            while (!CheckInput(choice, Moves.Length))
            {
                Console.WriteLine("Wrong input: ");
                choice = Console.ReadLine();
            }

            switch (choice)
            {
                case "0":
                    Exit();
                    break;
                case "?":
                    Help();
                    break;
                default:
                    PlayGame(int.Parse(choice));
                    break;
            }

        }

        private bool CheckInput(string s, int range)
        {
            IEnumerable<string> commands = new string[] { "0", "?" };
            if (commands.Contains(s)) return true;
            if (int.TryParse(s, out int index))
            {
                if (index < 1 || index > range) return false;
                return true;
            }

            return false;
        }

        private void PlayGame(int index)
        {
            if (hmac == null) return;

            index -= 1;
            Console.WriteLine($"Your move: {Moves[index]}");
            Console.WriteLine($"Computer move: {hmac.GetMove()}");
            Console.WriteLine(Game.GameResult(index,hmac.GetMoveIndex(),Moves.Length));
            Console.WriteLine($"HMAC key: {hmac.GetKey()}");
            Console.WriteLine($"You can check hmac here: {CheckLink}. Used method {Method}.");
            Exit();
        }

        private void Help()
        {
            Commands.ShowTable(Moves);
        }

        private void Exit()
        {
            Commands.Exit();
        }
    }
}
