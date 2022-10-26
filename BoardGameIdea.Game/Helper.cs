using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameIdea.Entities;

public static class Helper
{
    public enum TileType { EMPTY, WHITE, BLACK };
    public static ParallelOptions ParallelOptions = new ParallelOptions()
    {
        MaxDegreeOfParallelism = 5
    };

    public static List<List<T>> GetAllCombos<T>(List<T> list)
    {
        int comboCount = (int)Math.Pow(2, list.Count) - 1;
        List<List<T>> result = new List<List<T>>();
        for (int i = 1; i < comboCount + 1; i++)
        {
            // make each combo here
            result.Add(new List<T>());
            for (int j = 0; j < list.Count; j++)
            {
                if ((i >> j) % 2 != 0)
                    result.Last().Add(list[j]);
            }
        }
        return result;
    }
}

public static class PatternHelper
{
    public static T[,] RotateArrayClockwise<T>(this T[,] array)
    {
        int height = array.GetUpperBound(0) + 1;
        int width = array.GetUpperBound(1) + 1;
        T[,] newArray = new T[width, height];

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                int newRow = height - (row + 1);
                newArray[col, newRow] = array[row, col];
            }
        }
        return newArray;
    }

    public static (int, int)[] GetTrueValues(this bool[,] boolArray, int tilesAmount)
    {
        (int, int)[] result = new (int, int)[tilesAmount];
        int height = boolArray.GetUpperBound(0);
        int width = boolArray.GetUpperBound(1);
        int index = 0;
        for (int i = 0; i <= height; i++)
        {
            for (int j = 0; j <= width; j++)
            {
                if (boolArray[i, j])
                {
                    result[index] = (i, j);
                    index++;
                }
            }
        }
        return result;
    }
}