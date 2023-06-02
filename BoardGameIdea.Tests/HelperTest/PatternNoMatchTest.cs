using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests.HelperTest;

public class PatternNoMatchTest
{
    Pattern pattern;
    public PatternNoMatchTest()
    {
        PatternBase patternStruct = new("11", 1, 1);
        pattern = new(patternStruct);
    }

    [Test]
    public void TestPatternNoMatchOne()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Assert.IsFalse(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 0));
    }

    [Test]
    public void TestPatternOOB1()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Assert.IsFalse(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 2));
    }
    [Test]
    public void TestPatternOOB2()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Assert.IsFalse(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 3));
    }
    [Test]
    public void TestPatternOOB3()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        Assert.IsFalse(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], -1, 0));
    }
}
