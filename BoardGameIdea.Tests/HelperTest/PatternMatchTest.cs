using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests.HelperTest;

public class PatternMatchTest
{
    [Test]
    public void TestPatternMatchOne()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (0, 2)
        };
        PatternBase patternStruct = new("11", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        Assert.IsTrue(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }

    [Test]
    public void TestPatternMatchTwo()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (1, 2)
        };
        PatternBase patternStruct = new("10,01", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        Assert.IsTrue(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
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
        PatternBase patternStruct = new("01,10,00,10", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        Assert.IsTrue(Helper.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }
}