

namespace BoardGameIdea.Entities;

public class Pattern
{
    public string PatternString { get; set; }
    public int Score { get; set; }
    public int Rotations { get; set; }
    public Pattern(string patternString, int score, int rotationsAmount = 1)
    {
        PatternString = patternString;
        Score = score;
        Rotations = rotationsAmount;
    }

    public bool[,] ToBoolArray()
    {
        int width = PatternString.Split(",")[0].Length;
        int height = PatternString.Count(c => c == ',') + 1;
        bool[,] patternShape = new bool[height, width];
        int curHeight = 0;
        int curWidth = 0;
        foreach (char c in PatternString)
        {
            if (c == ',')
            {
                curHeight++;
                curWidth = 0;
                continue;
            }
            if (c == '1')
            {
                patternShape[curHeight, curWidth] = true;
            }
            curWidth++;
        }
        return patternShape;
    }
}
