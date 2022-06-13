using BoardGameIdea.Entities;
using System.Windows.Media;
using static BoardGameIdea.Entities.Helper;

namespace BoardGameIdea;

public static class Statics
{
    public const double GRID_HEIGHT = 700;
    public const int GRID_WIDTH = 7;
    public const int PATTERN_SIZE = 6;
    public const int PATTERN_CIRCLE_SIZE = 20;

    const int PLAYER_HITS = 21;
    const bool PATTERNS_OVERLAP = false;
    
    public static Pattern[] PATTERNS = new Pattern[5]{
        new("10,01", 1, 2),
        new("100,000,001", 2, 2),
        new("111,001", 3, 4),
        new("11,11", 2),
        new("1010,0001", 3, 4)
    };

    public static Game Game;

    public static void InitializeGame()
    {
        Game = new Game(GRID_WIDTH, PLAYER_HITS, PATTERNS_OVERLAP);
        Game.SetupPatterns(PATTERNS);
    }

    public static SolidColorBrush GetBrushFromPlayer(this TileType player)
    {
        switch(player)
        {
            case (TileType.BLACK):
                return BlackColor;
            case (TileType.WHITE):
                return WhiteColor;
            default:
                return NoColor;
        }
    }


    public static SolidColorBrush BlackColor = new SolidColorBrush(Colors.Black);
    public static SolidColorBrush WhiteColor = new SolidColorBrush(Colors.White);
    public static SolidColorBrush NoColor = new SolidColorBrush(Colors.Transparent);
}
