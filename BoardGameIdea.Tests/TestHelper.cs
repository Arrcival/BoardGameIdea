using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;
using BoardGameIdea.Entities.One;
using BoardGameIdea.Entities.Three;
using BoardGameIdea.Entities.Two;

namespace BoardGameIdea.Tests;

public static class TestHelper
{
    public static List<IGame> SetupGames(int gameWidth, int playerHits, bool patternOverlaps, params Pattern[] patterns)
    {
        var games = new List<IGame>();

        GameOne gameOne = new(gameWidth, playerHits, patternOverlaps);
        gameOne.SetupPatterns(patterns);
        games.Add(gameOne);
        GameTwo gameTwo = new(gameWidth, playerHits, patternOverlaps);
        gameTwo.SetupPatterns(patterns);
        games.Add(gameTwo);
        GameThree gameThree = new(gameWidth, playerHits, patternOverlaps);
        gameThree.SetupPatterns(patterns);
        games.Add(gameThree);
        return games;
    }
}
