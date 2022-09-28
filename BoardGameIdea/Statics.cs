using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;
using BoardGameIdea.Entities.One;
using System.Windows.Media;
using static BoardGameIdea.Entities.Helper;

namespace BoardGameIdea;

public static class Statics
{
    public const double GRID_HEIGHT = 700;
    public const int GRID_WIDTH = 9;
    public const int PATTERN_SIZE = 6;
    public const int PATTERN_CIRCLE_SIZE = 20;

    const int PLAYER_HITS = GRID_WIDTH * GRID_WIDTH - GRID_WIDTH;
    const bool PATTERNS_OVERLAP = true;
    
    public static Entities.Pattern[] PATTERNS = new Entities.Pattern[12]{
        new("101,000,101", 2, 1), // The square 
        new("1001,0000,0000,1001", 2, 1), // The big square 
        new("10001,00000,00000,00000,10001", 2, 1), // The really big square 
        new("100001,000000,000000,000000,000000,100001", 2, 1), // The biggest square 
        new("1111", 2, 2), // The line
        new("010,101,010", 2, 1), // The empty star
        new("010,111,010", 2, 1), // The full star
        new("00010,10000,00000,00001,01000", 3, 1), // The bended square
        new("010,001,100", 1, 4), // The small hook
        new("010,001,000,100", 1, 4), // The hook
        new("101,110,101", 2, 4), // The K
        new("011000,100000,000000,000000,000001,000110", 4, 2) // The mirror
    };

    public static IGame Game;

    public static void InitializeGame()
    {
        Game = new GameOne(GRID_WIDTH, PLAYER_HITS, PATTERNS_OVERLAP);
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
