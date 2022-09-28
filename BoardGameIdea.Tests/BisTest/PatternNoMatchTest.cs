using BoardGameIdea.Entities.One;
using static BoardGameIdea.Entities.Bis.HelperBis;

namespace BoardGameIdea.Tests.BisTest;

public class PatternNoMatchBisTest
{
    [Test]
    public void TestPatternNoMatchOne()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Pattern pattern = new PatternOne("11", 1, 1);
        Assert.IsFalse(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 0));
    }

    [Test]
    public void TestPatternOOB1()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Pattern pattern = new PatternOne("11", 1, 1);
        Assert.IsFalse(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 2));
    }
    [Test]
    public void TestPatternOOB2()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Pattern pattern = new PatternOne("11", 1, 1);
        Assert.IsFalse(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 3));
    }
    [Test]
    public void TestPatternOOB3()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Pattern pattern = new PatternOne("11", 1, 1);
        Assert.IsFalse(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], -1, 0));
    }
}