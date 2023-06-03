namespace BoardGameIdea.Entities;

public class PatternInflated
{
    public (int, int)[] Coordinates;
    public int Score;

    public PatternInflated((int, int)[] coordinates, int x, int y, int score)
    {
        Coordinates = new (int, int)[coordinates.Length];
        for (int i = 0; i < coordinates.Length; i++)
        {
            Coordinates[i] = new(coordinates[i].Item1 + x, coordinates[i].Item2 += y);
        }
        Score = score;
    }
}