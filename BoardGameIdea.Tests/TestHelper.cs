using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;

namespace BoardGameIdea.Tests;

public static class TestHelper
{
    public static IGame SetupGame(int gameWidth, int playerHits, bool patternOverlaps, params PatternBase[] patterns)
    {
        Game game = new(gameWidth, playerHits, patternOverlaps);
        game.SetupPatterns(patterns);
        return game;
    }
}
