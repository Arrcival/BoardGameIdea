namespace BoardGameIdea.Entities.Three;

public static class HelperThree
{
    public static bool CanPatternWork(List<(int, int)> playerHits, (int, int)[] pattern, int x, int y)
    {
        for(int i = 0; i < pattern.Length; i++)
        {
            (int, int) coords = pattern[i];
            coords.Item1 += x;
            coords.Item2 += y;
            if (!playerHits.Contains(coords)) return false;
        }
        return true;
    }

    public static int GetBoardPointsOverlap(List<(int, int)> playerHits, PatternThree[] patterns, int gameWidth, int minimumTiles = 1)
    {
        if (playerHits.Count < minimumTiles) return 0;

        int finalScore = 0;
        for (int x = 0; x < gameWidth; x++)
        {
            for (int y = 0; y < gameWidth; y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    PatternThree currentPattern = patterns[i];
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

    public static int GetBoardPoints(List<(int, int)> playerHits, PatternThree[] patterns, int gameWidth, int minimumTiles = 1)
    {
        if (playerHits.Count < minimumTiles) return 0;

        var patternsWorking = new List<PatternInflated>();
        for (int x = 0; x < gameWidth; x++)
        {
            for (int y = 0; y < gameWidth; y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    PatternThree currentPattern = patterns[i];
                    (int, int)[][] patternsTrueShapes = currentPattern.PatternTrueShapes;
                    int patternsCount = patternsTrueShapes.GetUpperBound(0);
                    for (int j = 0; j <= patternsCount; j++)
                    {
                        if (playerHits.Count >= currentPattern.TilesAmount)
                        {
                            break;
                        }
                        if(CanPatternWork(playerHits, patternsTrueShapes[j], x, y))
                        {
                            var patternInflated = new PatternInflated(patternsTrueShapes[j], x, y, currentPattern.Score);
                            patternsWorking.Add(patternInflated);
                        }
                    }
                }
            }
        }
        var everyPossiblities = Helper.GetAllCombos(patternsWorking);
        int maximumPoints = patternsWorking.Sum(p => p.Score);
        for(int j = maximumPoints; j > 0; j--)
        {
            var currentPossibilities = everyPossiblities.Where(_ => _.Sum(p => p.Score) == j).ToList();
            for (int k = 0; k < currentPossibilities.Count(); k++)
            {
                var current = currentPossibilities[k];
                for (int l = 0; l < current.Count - 1; l++)
                {
                    for (int m = l + 1; m < current.Count; m++)
                    {
                        if (current[l].Coordinates.Intersect(current[m].Coordinates).Count() == 0)
                        {
                            return j;
                        }
                    }
                }
            }
        }

        return 0;
    }
}
