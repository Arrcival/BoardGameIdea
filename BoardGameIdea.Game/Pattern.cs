namespace BoardGameIdea.Entities;

public class Pattern
{
    int rotations;
    public bool[,] PatternShape;
    public int Score;
    public int TilesAmount;
    public bool[][,] PatternShapes { get; set; }
    public (int, int)[][] PatternTrueShapes { get; set; }

    public Pattern(string patternString, int score, int rotationsAmount = 1)
    {
        TilesAmount = 0;
        rotations = rotationsAmount;
        Score = score;
        int width = patternString.Split(",")[0].Length;
        int height = patternString.Count(c => c == ',') + 1;
        PatternShape = new bool[height, width];
        int curHeight = 0;
        int curWidth = 0;
        foreach(char c in patternString)
        {
            if (c == ',')
            {
                curHeight++;
                curWidth = 0;
                continue;
            }
            if(c == '1')
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
