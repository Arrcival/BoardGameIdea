using static BoardGameIdea.Entities.HelperConst;

namespace BoardGameIdea.Entities;

public static class Helper
{
    public static bool CanPatternWork(List<(int, int)> playerHits, (int, int)[] pattern, int x, int y)
    {
        for (int i = 0; i < pattern.Length; i++)
        {
            (int, int) coords = pattern[i];
            coords.Item1 += x;
            coords.Item2 += y;
            if (!playerHits.Contains(coords)) return false;
        }
        return true;
    }

    public static List<(int, int)> RemovePattern(List<(int, int)> playerHits, (int, int)[] pattern, int x, int y)
    {
        List<(int, int)> newPlayerHits = new();

        (int, int)[] patternInflated = new (int, int)[pattern.Length];
        for (int i = 0; i < pattern.Length; i++)
        {
            patternInflated[i] = (pattern[i].Item1 + x, pattern[i].Item2 + y);
        }
        for (int i = 0; i < playerHits.Count; i++)
        {
            if (!patternInflated.Contains(playerHits[i]))
                newPlayerHits.Add(playerHits[i]);
        }

        return newPlayerHits;
    }

    public static int GetBoardPointsOverlap(List<(int, int)> playerHits, Pattern[] patterns, int gameWidth, int minimumTiles = 1)
    {
        if (playerHits.Count < minimumTiles) return 0;

        int finalScore = 0;
        for (int x = 0; x < gameWidth; x++)
        {
            for (int y = 0; y < gameWidth; y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    Pattern currentPattern = patterns[i];
                    (int, int)[][] patternsTrueShapes = currentPattern.PatternTrueShapes;
                    int patternsCount = patternsTrueShapes.GetUpperBound(0);
                    for (int j = 0; j <= patternsCount; j++)
                    {
                        if (playerHits.Count >= currentPattern.TilesAmount && CanPatternWork(playerHits, patternsTrueShapes[j], x, y))
                        {
                            finalScore += currentPattern.Score;
                            break;
                        }
                    }
                }
            }
        }
        return finalScore;
    }

    public static int GetBoardPoints(List<(int, int)> playerHits, Pattern[] patterns, int gameWidth, int minimumTiles = 1)
    {
        if (playerHits.Count < minimumTiles) return 0;

        int finalScore = 0;
        for (int x = 0; x < gameWidth; x++)
        {
            for (int y = 0; y < gameWidth; y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    Pattern currentPattern = patterns[i];
                    (int, int)[][] patternsTrueShapes = currentPattern.PatternTrueShapes;
                    int patternsCount = patternsTrueShapes.GetUpperBound(0);
                    for (int j = 0; j <= patternsCount; j++)
                    {
                        if (playerHits.Count >= currentPattern.TilesAmount && CanPatternWork(playerHits, patternsTrueShapes[j], x, y))
                        {
                            List<(int, int)> newPlayerHits = RemovePattern(playerHits, patternsTrueShapes[j], x, y);
                            int patternScore = currentPattern.Score + GetBoardPoints(newPlayerHits, patterns, gameWidth, minimumTiles);
                            if (patternScore > finalScore) finalScore = patternScore;
                            break;
                        }
                    }
                }
            }
        }
        return finalScore;
    }
}