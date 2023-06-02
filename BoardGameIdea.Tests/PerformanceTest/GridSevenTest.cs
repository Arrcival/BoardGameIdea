using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;

namespace BoardGameIdea.Tests.PerformanceTest;

public class GridSevenTest
{
    IGame game;

    [SetUp]
    public void Setup()
    {
        PatternBase[] patterns = new PatternBase[5]{
            new("10,01", 1, 2),
            new("100,000,001", 2, 2),
            new("111,001", 3, 4),
            new("11,11", 2),
            new("1010,0001", 3, 4)
        };
        game = TestHelper.SetupGame(7, 21, false, patterns);
    }

    [Test, MaxTime(600)]
    public void TestPerformanceSevenBySeven()
    {
        game.SetupFromString("wbwbwbw,bwbwbwb,wbwbwbw,.......,wbwbwbw,.......,.......");
        Assert.That(game.GetScore(HelperConst.TileType.WHITE), Is.EqualTo(14));
    }
}
