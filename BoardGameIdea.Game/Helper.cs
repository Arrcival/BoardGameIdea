using static BoardGameIdea.Entities.HelperConst;

namespace BoardGameIdea.Entities;

public static class Helper
{
    public static bool CanPatternWork(TileType[,] board, bool[,] pattern, int x, int y, TileType playerType)
    {
        int patternHeight = pattern.GetUpperBound(0);
        int patternWidth = pattern.GetUpperBound(1);

        // out of bounds
        if (x + patternHeight > board.GetUpperBound(0) || y + patternWidth > board.GetUpperBound(1))
            return false;
        if (x < 0 || y < 0) return false;

        for (int i = 0; i <= patternHeight; i++)
            for (int j = 0; j <= patternWidth; j++)
                if (pattern[i, j] && board[x + i, y + j] != playerType) return false;

        return true;
    }

    public static bool CanPatternWork(TileType[,] board, (int, int)[] trueLocations, int x, int y, TileType playerType)
    {
        int boardHeight = board.GetUpperBound(0);
        int boardWidth = board.GetUpperBound(1);
        for (int i = 0; i < trueLocations.Length; i++)
        {
            int patternX = trueLocations[i].Item1;
            int patternY = trueLocations[i].Item2;
            if (x + patternX > boardHeight || y + patternY > boardWidth) return false;
            if (board[x + patternX, y + patternY] != playerType) return false;
        }

        return true;
    }

    public static TileType[,] RemovePattern(TileType[,] board, bool[,] pattern, int x, int y)
    {
        int patternHeight = pattern.GetUpperBound(0);
        int patternWidth = pattern.GetUpperBound(1);
        TileType[,]? newBoard = board.Clone() as TileType[,];
        if (newBoard == null) return board;

        // out of bounds
        if (x + patternHeight > board.GetUpperBound(0) || y + patternWidth > board.GetUpperBound(1))
            return newBoard;
        if (x < 0 || y < 0) return newBoard;

        for (int i = 0; i <= patternHeight; i++)
            for (int j = 0; j <= patternWidth; j++)
                if (pattern[i, j]) newBoard[x + i, y + j] = TileType.EMPTY;

        return newBoard;
    }


    public static int GetBoardPointsOld(TileType[,] currentBoard, Pattern[] patterns, TileType player, int minimumTiles = 1)
    {
        int playerHits = currentBoard.PlayerHits(player);
        if (playerHits < minimumTiles) return 0;

        int finalScore = 0;
        int height = currentBoard.GetUpperBound(0);
        int width = currentBoard.GetUpperBound(1);
        for (int x = 0; x <= height; x++)
        {
            for (int y = 0; y <= width; y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    bool[][,] patternsArray = patterns[i].PatternShapes;
                    int patternsCount = patternsArray.GetUpperBound(0);
                    for (int j = 0; j <= patternsCount; j++)
                    {
                        if (playerHits >= patterns[i].TilesAmount && CanPatternWork(currentBoard, patternsArray[j], x, y, player))
                        {
                            TileType[,] newBoard = RemovePattern(currentBoard, patternsArray[j], x, y);
                            int patternScore = patterns[i].Score + GetBoardPointsOld(newBoard, patterns, player, minimumTiles);
                            if (patternScore > finalScore) finalScore = patternScore;
                            break;
                        }
                    }
                }
            }
        }
        return finalScore;
    }
    public static int GetBoardPoints(TileType[,] currentBoard, Pattern[] patterns, TileType player, int minimumTiles = 1)
    {
        int playerHits = currentBoard.PlayerHits(player);
        if (playerHits < minimumTiles) return 0;

        int finalScore = 0;
        int height = currentBoard.GetUpperBound(0);
        int width = currentBoard.GetUpperBound(1);
        for (int x = 0; x <= height; x++)
        {
            for (int y = 0; y <= width; y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    Pattern currentPattern = patterns[i];
                    bool[][,] patternsArray = currentPattern.PatternShapes;
                    (int, int)[][] patternsTrueShapes = currentPattern.PatternTrueShapes;
                    int patternsCount = patternsArray.GetUpperBound(0);
                    for (int j = 0; j <= patternsCount; j++)
                    {
                        if (playerHits >= currentPattern.TilesAmount && CanPatternWork(currentBoard, patternsTrueShapes[j], x, y, player))
                        {
                            TileType[,] newBoard = RemovePattern(currentBoard, patternsArray[j], x, y);
                            int patternScore = currentPattern.Score + GetBoardPoints(newBoard, patterns, player, minimumTiles);
                            if (patternScore > finalScore) finalScore = patternScore;
                            break;
                        }
                    }
                }
            }
        }
        return finalScore;
    }

    public static int GetBoardPointsOverlap(TileType[,] currentBoard, Pattern[] patterns, TileType player)
    {
        int score = 0;
        for (int x = 0; x <= currentBoard.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= currentBoard.GetUpperBound(1); y++)
            {
                for (int i = 0; i < patterns.Length; i++)
                {
                    bool[][,] patternsArray = patterns[i].PatternShapes;
                    for (int j = 0; j <= patternsArray.GetUpperBound(0); j++)
                    {
                        if (CanPatternWork(currentBoard, patternsArray[j], x, y, player))
                        {
                            score += patterns[i].Score;
                            break;
                        }
                    }
                }
            }
        }
        return score;
    }


    public static int PlayerHits(this TileType[,] board, TileType tiletype)
    {
        int count = 0;
        for (int i = 0; i <= board.GetUpperBound(0); i++)
            for (int j = 0; j <= board.GetUpperBound(1); j++)
                if (board[i, j] == tiletype) count++;
        return count;
    }


}
