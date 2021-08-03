using System;

namespace TestAll
{
    //A tic-tac-toe game with the possibility of a double win
    class Program
	{

        public enum Mark
        {
            Empty,
            Cross,
            Circle
        }

        public enum GameResult
        {
            CrossWin,
            CircleWin,
            Draw
        }

        public static void Main()
        {
            Run("XXX OO. ...");
            Run("OXO XO. .XO");
            Run("OXO XOX OX.");
            Run("XOX OXO OXO");
            Run("... ... ...");
            Run("XXX OOO ...");
            Run("XOO XOO XX.");
            Run(".O. XO. XOX");
        }

        private static void Run(string description)
        {
            Console.WriteLine(description.Replace(" ", Environment.NewLine));
            Console.WriteLine(GetGameResult(CreateFromString(description)));
            Console.WriteLine();
        }

        private static Mark[,] CreateFromString(string str)
        {
            var field = str.Split(' ');
            var ans = new Mark[3, 3];
            for (int x = 0; x < field.Length; x++)
                for (var y = 0; y < field.Length; y++)
                    ans[x, y] = field[x][y] == 'X' ? Mark.Cross : (field[x][y] == 'O' ? Mark.Circle : Mark.Empty);
            return ans;
        }

        public static GameResult GetGameResult(Mark[,] field)
        {
            int whoWin = 0;
            if (IsWin(field, Mark.Cross)) 
                whoWin++;
            if (IsWin(field, Mark.Circle))
                whoWin--;

            if (whoWin == 0)
                return GameResult.Draw;
            return (whoWin == -1) ? GameResult.CircleWin : GameResult.CrossWin;
        }

        public static bool IsWin(Mark[,] field, Mark mark)
        {
            int[][] winPositions = new int[8][];
            winPositions[0] = new int[] { 0, 0, 0, 1 };
            winPositions[1] = new int[] { 1, 0, 0, 1 };
            winPositions[2] = new int[] { 2, 0, 0, 1 };
            winPositions[3] = new int[] { 0, 0, 1, 0 };
            winPositions[4] = new int[] { 0, 1, 1, 0 };
            winPositions[5] = new int[] { 0, 2, 1, 0 };
            winPositions[6] = new int[] { 0, 0, 1, 1 };
            winPositions[7] = new int[] { 0, 2, 1, -1 };

            foreach (var position in winPositions)
            {
                if (Check(field, mark, position[0], position[1], position[2], position[3]))
                    return true;
            }
            return false;
        }

        public static bool Check(Mark[,] field, Mark mark, int x0, int y0, int dx, int dy)
        {
            int line = 0;
            int i = x0;
            int j = y0;
            while (i < field.GetLength(0) && j < field.GetLength(1))
            {
                if (field[i, j] == mark)
                    line++;
                if (line == 3)
                        return true;
                i += dx;
                j += dy;
            }
            return false;
        }
    }
}
