using BoardGameIdea.Entities.One;
using static BoardGameIdea.Entities.Bis.HelperBis;

namespace BoardGameIdea.Tests.BisTest;

public class PatternMatchBisTest
{
    [Test]
    public void TestPatternMatchOne()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (0, 2)
        };
        Pattern pattern = new PatternOne("11", 1, 1);
        Assert.IsTrue(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }

    [Test]
    public void TestPatternMatchTwo()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (1, 2)
        };
        Pattern pattern = new PatternOne("10,01", 1, 1);
        Assert.IsTrue(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }
    [Test]
    public void TestPatternMatchBig()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 2),
            (1, 1),
            (3, 1),
        };
        Pattern pattern = new PatternOne("01,10,00,10", 1, 1);
        Assert.IsTrue(CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }
}