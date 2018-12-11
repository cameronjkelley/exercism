using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public static class Minesweeper
    {
        public static string[] Annotate(string[] input)
        {
            List<string> output = new List<string>();

            if (input.Length > 0)
            {
                for (int row = 0; row < input.Length; row++)
                {
                    StringBuilder sb = new StringBuilder("");

                    for (int col = 0; col < input[row].Length; col++)
                    {
                        if (input[row][col] == '*')
                        {
                            sb.Append('*');
                        }
                        else
                        {
                            List<Tuple<int, int>> perimeter = CreatePerimeter(input, row, col);
                            int mineCount = CountPerimeter(input, perimeter);

                            sb.Append(mineCount > 0 ? mineCount.ToString() : " ");
                        }
                    }
                    output.Add(sb.ToString());
                }
            }

            return output.ToArray();
        }
        
        private static List<Tuple<int, int>> CreatePerimeter(string[] minefield, int row, int column)
        {
            int prevRow = row -1,
                nextRow = row + 1, 
                prevCol = column - 1, 
                nextCol = column + 1;

            List<Tuple<int, int>> perimeter = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(prevRow, prevCol),
                new Tuple<int, int>(prevRow, column),
                new Tuple<int, int>(prevRow, nextCol),
                new Tuple<int, int>(row, prevCol),
                new Tuple<int, int>(row, nextCol),
                new Tuple<int, int>(nextRow, prevCol),
                new Tuple<int, int>(nextRow, column),
                new Tuple<int, int>(nextRow, nextCol)
            };

            foreach (Tuple<int, int> coordinate in perimeter.ToList())
            {
                if (coordinate.Item1 < 0 || 
                    coordinate.Item2 < 0 ||
                    coordinate.Item1 > minefield.Length - 1 || 
                    coordinate.Item2 > minefield[0].Length - 1)
                {
                    perimeter.Remove(coordinate);
                }
            }

            return perimeter;
        }

        private static int CountPerimeter(string[] minefield, List<Tuple<int, int>> perimeter)
        {
            int perimeterCount = 0;

            foreach(Tuple<int, int> coordinate in perimeter)
            {
                if (minefield[coordinate.Item1][coordinate.Item2] == '*')
                {
                    perimeterCount++;
                }
            }
        
            return perimeterCount;
        }
    }
}
