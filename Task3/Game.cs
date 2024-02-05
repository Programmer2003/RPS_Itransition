namespace Task3
{
    public enum Winner
    {
        First = -1,
        Draw = 0,
        Second = 1
    }

    static class Game
    {

        private static Winner PlayGame(int first_move, int second_move, int moves)
        {
            int result = first_move - second_move;
            if (result == 0) return Winner.Draw;

            if (result < 0) result = moves + result;

            if (result < moves / 2.0f) return Winner.First;
            return Winner.Second;
        }

        public static string GameResult(int first_move, int second_move, int moves, bool table = false)
        {
            Winner winner = PlayGame(first_move, second_move, moves);
            switch (winner)
            {
                case Winner.First:
                    return table ? "Win" : "You win!";
                case Winner.Draw:
                    return table ? "Draw" : "Draw";
                case Winner.Second:
                    return table ? "Lose" : "You lose :(";
                default:
                    return "Undefined";
            }
        }
    }
}
