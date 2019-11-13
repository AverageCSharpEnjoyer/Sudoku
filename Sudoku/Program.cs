using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sudoku1 = {
                            { 2 , 9 , 5 , 7 , 4 , 3 , 8 , 6 , 1 },
                            { 4 , 3 , 1 , 8 , 6 , 5 , 9 , 0 , 0 },
                            { 8 , 7 , 6 , 1 , 9 , 2 , 5 , 4 , 3 },
                            { 3 , 8 , 7 , 4 , 5 , 9 , 2 , 1 , 6 },
                            { 6 , 1 , 2 , 3 , 8 , 7 , 4 , 9 , 5 },
                            { 5 , 4 , 9 , 2 , 1 , 6 , 7 , 3 , 8 },
                            { 7 , 6 , 3 , 5 , 2 , 4 , 1 , 8 , 9 },
                            { 9 , 2 , 8 , 6 , 7 , 1 , 3 , 5 , 4 },
                            { 1 , 5 , 4 , 9 , 3 , 8 , 6 , 0 , 0 },
                            };

            int[,] sudoku2 = {
                            { 3 , 0 , 6 , 5 , 0 , 8 , 4 , 0 , 0 },
                            { 5 , 2 , 0 , 0 , 0 , 0 , 0 , 0 , 0 },
                            { 0 , 8 , 7 , 0 , 0 , 0 , 0 , 3 , 1 },
                            { 0 , 0 , 3 , 0 , 1 , 0 , 0 , 8 , 0 },
                            { 9 , 0 , 0 , 8 , 6 , 3 , 0 , 0 , 5 },
                            { 0 , 5 , 0 , 0 , 9 , 0 , 6 , 0 , 0 },
                            { 1 , 3 , 0 , 0 , 0 , 0 , 2 , 5 , 0 },
                            { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 7 , 4 },
                            { 0 , 0 , 5 , 2 , 0 , 6 , 3 , 0 , 0 },
                            };

            //Console.WriteLine(Solve(ref sudoku1));

            Console.WriteLine(Solve(ref sudoku2));

        }


        static int Solve(ref int[,] sudokuArray, int count = 0, int i = 0, int j = 0)
        {
            if (i == 9)
            {
                i = 0;
                if (++j == 9)
                {
                    return 1 + count;
                }
            }

            if (sudokuArray[i, j] != 0)
            {
                return Solve(ref sudokuArray, count, i + 1, j);
            }

            for (int val = 1; val <= 9 && count < 2; ++val)
            {
                if (canInsert(i, j, val, ref sudokuArray))
                {
                    sudokuArray[i, j] = val;
                    count = Solve(ref sudokuArray, count, i + 1, j);
                }
            }
            sudokuArray[i, j] = 0;
            return count;
        }

        static bool solve(ref int[,] cells, int i = 0, int j = 0)
        {
            if (i == 9)
            {
                i = 0;
                if (++j == 9)
                    return true;
            }
            if (cells[i, j] != 0)  // skip filled cells
                return solve(ref cells, i + 1, j);

            for (int val = 1; val <= 9; val++)
            {
                if (canInsert(i, j, val, ref cells))
                {
                    cells[i, j] = val;
                    if (solve(ref cells, i + 1, j))
                        return true;
                    cells[i, j] = 0; // reset on backtrack
                }
            }
            return false;
        }

        static bool canInsert(int i, int j, int val, ref int[,] sudokuArray)
        {
            for (int x = 0; x < 9; x++)
            {
                if (sudokuArray[x, j] == val)
                {
                    return false;
                }
            }
            for (int y = 0; y < 9; y++)
            {
                if (sudokuArray[i, y] == val)
                {
                    return false;
                }
            }

            //granice komórki
            int x1 = 3 * (i / 3);
            int y1 = 3 * (j / 3);
            int x2 = x1 + 2;
            int y2 = y1 + 2;

            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    if (sudokuArray[x, y] == val)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        static bool isValidCell(ref int[,] sudokuArray, int x, int y, int value)
        {
            if (sudokuArray[x, y] == value)
            {
                return false;
            }
            return true;
        }


    }
}
