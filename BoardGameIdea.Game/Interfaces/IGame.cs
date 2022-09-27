using static BoardGameIdea.Entities.Helper;

namespace BoardGameIdea.Entities.Interfaces;

public interface IGame
{
    public int WhiteScore { get { return GetScore(TileType.WHITE); } }
    public int BlackScore { get { return GetScore(TileType.BLACK); } }

    void SetupPatterns(params Pattern[] playerPatterns);
    void Play(int x, int y);
    bool IsGameOver();
    int GetScore(TileType tileType);

    TileType[,] GetBoard();
}
