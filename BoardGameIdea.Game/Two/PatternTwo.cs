namespace BoardGameIdea.Entities.Two;

public class PatternTwo
{
    int rotations;
    public bool[,] PatternShape;
    public int Score;
    public int TilesAmount;
    public bool[][,] PatternShapes { get; set; }
    public (int, int)[][] PatternTrueShapes { get; set; }

    public PatternTwo(Pattern pattern)
    {
        string patternString = pattern.PatternString;
        TilesAmount = 0;
        rotations = pattern.Rotations;
        Score = pattern.Score;
        int width = patternString.Split(",")[0].Length;
        int height = patternString.Count(c => c == ',') + 1;
        PatternShape = new bool[height, width];
        int curHeight = 0;
        int curWidth = 0;
        foreach (char c in patternString)
        {
            if (c == ',')
            {
                curHeight++;
                curWidth = 0;
                continue;
            }
            if (c == '1')
            {
                PatternShape[curHeight, curWidth] = true;
                TilesAmount++;
            }
            curWidth++;
        }
        ComputePattern();
    }

    void ComputePattern()
    {
        if (rotations == 1)
            PatternShapes = new bool[][,] { PatternShape };
        else if (rotations == 2)
            PatternShapes = new bool[][,]
            {
                PatternShape,
                PatternShape.RotateArrayClockwise()
            };
        else
        {
            PatternShapes = new bool[][,]
            {
                PatternShape,
                PatternShape.RotateArrayClockwise(),
                PatternShape.RotateArrayClockwise().RotateArrayClockwise(),
                PatternShape.RotateArrayClockwise().RotateArrayClockwise().RotateArrayClockwise(),
            };
        }
        int amountShapes = PatternShapes.GetUpperBound(0) + 1;
        PatternTrueShapes = new (int, int)[amountShapes][];

        for (int i = 0; i < amountShapes; i++)
        {
            PatternTrueShapes[i] = PatternShapes[i].GetTrueValues(TilesAmount);
        }
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