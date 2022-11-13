using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;
using BoardGameIdea.Entities.One;
using BoardGameIdea.Entities.Three;
using BoardGameIdea.Entities.Two;

namespace BoardGameIdea.Tests.PerformanceTest;

public class GridSevenTest
{
    List<IGame> games;
    GameOne gameOne;
    GameTwo gameTwo;
    GameThree gameThree;

    [SetUp]
    public void Setup()
    {
        Pattern[] patterns = new Pattern[5]{
            new("10,01", 1, 2),
            new("100,000,001", 2, 2),
            new("111,001", 3, 4),
            new("11,11", 2),
            new("1010,0001", 3, 4)
        };
        games = TestHelper.SetupGames(7, 21, false, patterns);

        gameOne = new(7, 21, false);
        gameTwo = new(7, 21, false);
        gameThree = new(7, 21, false);
        gameOne.SetupPatterns(patterns);
        gameTwo.SetupPatterns(patterns);
        gameThree.SetupPatterns(patterns);
    }

    [Test, MaxTime(600)]
    public void TestPerformanceOne()
    {
        gameOne.SetupFromString("wbwbwbw,bwbwbwb,wbwbwbw,.......,wbwbwbw,.......,.......");
        Assert.That(gameOne.GetScore(Helper.TileType.WHITE), Is.EqualTo(14));
    }

    [Test, MaxTime(600)]
    public void TestPerformanceTwo()
    {
        gameTwo.SetupFromString("wbwbwbw,bwbwbwb,wbwbwbw,.......,wbwbwbw,.......,.......");
        Assert.That(gameTwo.GetScore(Helper.TileType.WHITE), Is.EqualTo(14));
    }

    [Test, MaxTime(600)]
    public void TestPerformanceThree()
    {
        gameTwo.SetupFromString("wbwbwbw,bwbwbwb,wbwbwbw,.......,wbwbwbw,.......,.......");
        Assert.That(gameThree.GetScore(Helper.TileType.WHITE), Is.EqualTo(14));
    }
}
