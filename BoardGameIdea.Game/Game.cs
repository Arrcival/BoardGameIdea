using BoardGameIdea.Entities.Interfaces;
using static BoardGameIdea.Entities.HelperConst;

namespace BoardGameIdea.Entities;

public class Game : IGame
{
    List<(int, int)> whitePlayerHits;
    List<(int, int)> blackPlayerHits;

    int playerHits;
    bool patternOverlapScore;
    TileType currentPlayerMove;
    Pattern[] patterns;
    int patternsMinimumCount;
    int width;

    public Game(int width) : this(width, width * width - width) { }
    public Game(int width, int playerHits, bool overlapPatterns = false)
    {
        whitePlayerHits = new();
        blackPlayerHits = new();
        this.playerHits = playerHits;
        patternOverlapScore = overlapPatterns;
        currentPlayerMove = TileType.WHITE;
        this.width = width;
    }
    public void SetupPatterns(params PatternBase[] playerPatterns)
    {
        patterns = new Pattern[playerPatterns.Length];
        for (int i = 0; i < playerPatterns.Length; i++)
        {
            patterns[i] = new Pattern(playerPatterns[i]);
        }
        patternsMinimumCount = patterns.Select(p => p.TilesAmount).Min();
    }

    #region Base methods
    public void Play(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= width) return;
        if (whitePlayerHits.Contains((x, y)) || blackPlayerHits.Contains((x, y))) return;

        if (currentPlayerMove == TileType.WHITE)
            whitePlayerHits.Add((x, y));
        else
            blackPlayerHits.Add((x, y));
        currentPlayerMove = currentPlayerMove == TileType.WHITE ? TileType.BLACK : TileType.WHITE;
    }

    public bool IsGameOver()
    {
        return whitePlayerHits.Count >= playerHits && blackPlayerHits.Count >= playerHits;
    }

    #endregion

    #region Scoring & Patterns
    int GetScore(List<(int, int)> playerHits)
    {
        return Helper.GetBoardPoints(playerHits, patterns, width, patternsMinimumCount);
    }
    int GetScoreOverlap(List<(int, int)> playerHits)
    {
        return Helper.GetBoardPointsOverlap(playerHits, patterns, width, patternsMinimumCount);
    }

    public void SetupFromString(string str)
    {
        str = str.ToLower();
        int count = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (str[count] == ',') count++;

                if (str[count] == 'w') whitePlayerHits.Add((i, j));
                if (str[count] == 'b') blackPlayerHits.Add((i, j));
                count++;
                if (count >= str.Length) return;
            }
        }
    }

    public TileType[,] GetBoard()
    {
        TileType[,] board = new TileType[width, width];
        foreach (var whiteMoves in whitePlayerHits)
        {
            board[whiteMoves.Item1, whiteMoves.Item2] = TileType.WHITE;
        }
        foreach (var blackMoves in blackPlayerHits)
        {
            board[blackMoves.Item1, blackMoves.Item2] = TileType.BLACK;
        }
        return board;
    }

    public int GetScore(TileType tileType)
    {
        if (patternOverlapScore)
        {
            if (tileType == TileType.BLACK)
                return GetScoreOverlap(blackPlayerHits);
            return GetScoreOverlap(whitePlayerHits);
        }
        if (tileType == TileType.BLACK)
            return GetScore(blackPlayerHits);
        return GetScore(whitePlayerHits);

    }

    #endregion
}