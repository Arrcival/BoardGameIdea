using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests.PerformanceTest;

public class GridSevenTest
{
    GameOne currentGame;
    [SetUp]
    public void Setup()
    {
        currentGame = new GameOne(7, 21, false);
        Pattern[] patterns = new Pattern[5]{
            new("10,01", 1, 2),
            new("100,000,001", 2, 2),
            new("111,001", 3, 4),
            new("11,11", 2),
            new("1010,0001", 3, 4)
        };
        currentGame.SetupPatterns(patterns);
    }

    [Test, MaxTime(300)]
    public void TestPerformanceOne()
    {
        currentGame.SetupFromString("wbwbwbw,bwbw...,wbwbwbw,.......,wbwbwbw,.......,.......");
        Assert.That(currentGame.WhiteScore, Is.EqualTo(12));
    }
    [Test, MaxTime(600)]
    public void TestPerformanceFurther()
    {
        currentGame.SetupFromString("wbwbwbw,bwbwbwb,wbwbwbw,.......,wbwbwbw,.......,.......");
        Assert.That(currentGame.WhiteScore, Is.EqualTo(14));
    }
    [Test, MaxTime(1000)]
    public void TestPerformanceEvenFurtherOne()
    {
        currentGame.SetupFromString("wbwbwbw,bwbwbwb,wbwbwbw,bwb....,wbwbwbw,.......,.......");
        Assert.That(currentGame.WhiteScore, Is.EqualTo(15));
    }
}
