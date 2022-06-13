using System.Linq;
using static BoardGameIdea.Entities.Helper;

namespace BoardGameIdea.Entities;

public class Game
{
    public TileType[,] Board;
    int playerHits;
    bool patternOverlapScore;
    TileType currentPlayerMove;
    Pattern[] patterns;
    int patternsMinimumCount;
    int width;

    public int WhiteScore { get { return GetScore(TileType.WHITE); } }
    public int BlackScore { get { return GetScore(TileType.BLACK); } }

    public Game(int width) : this(width, width * width - width) { }
    public Game(int width, int playerHits, bool overlapPatterns = false)
    {
        Board = new TileType[width, width];
        this.playerHits = playerHits;
        patternOverlapScore = overlapPatterns;
        currentPlayerMove = TileType.WHITE;
        this.width = width;
    }

    public void SetupPatterns(params Pattern[] playerPatterns)
    {
        patterns = playerPatterns;
        patternsMinimumCount = patterns.Select(p => p.TilesAmount).Min();
    }

    #region Base methods
    public void Play(int x, int y)
    {
        if (x < 0 || x >= width || y < 0 || y >= width) return;
        if (Board[x, y] != TileType.EMPTY) return;

        Board[x, y] = currentPlayerMove;
        currentPlayerMove = currentPlayerMove == TileType.WHITE ? TileType.BLACK : TileType.WHITE;
    }

    public bool IsGameOver()
    {
        return Board.PlayerHits(TileType.WHITE) >= playerHits && Board.PlayerHits(TileType.BLACK) >= playerHits;
    }

    #endregion


    #region Scoring & Patterns
    int GetScore(TileType tileType)
    {
        if (!patternOverlapScore)
            return GetBoardPoints(Board, patterns, tileType, patternsMinimumCount);
        else
            return GetBoardPointsOverlap(Board, patterns, tileType);
    }

    public void SetupFromString(string str)
    {
        str = str.ToLower();
        int height = Board.GetUpperBound(0) + 1;
        int width = Board.GetUpperBound(1) + 1;
        int count = 0;
        for(int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (str[count] == ',') count++;

                Board[i, j] = TileType.EMPTY;
                if (str[count] == 'w') Board[i, j] = TileType.WHITE;
                if (str[count] == 'b') Board[i, j] = TileType.BLACK;
                count++;
                if (count >= str.Length) return;
            }
        }            
    }

    #endregion
}
