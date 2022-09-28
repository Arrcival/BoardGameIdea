using BoardGameIdea.Entities;
using BoardGameIdea.Entities.One;
using BoardGameIdea.Entities.Two;

namespace BoardGameIdea.Tests.TwoTest.HelperTest;

public class PatternTwoMatchBisTest
{
    [Test]
    public void TestPatternMatchOne()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (0, 2)
        };
        Pattern patternStruct = new("11", 1, 1);
        PatternTwo pattern = new PatternTwo(patternStruct);
        Assert.IsTrue(HelperTwo.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }

    [Test]
    public void TestPatternMatchTwo()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (1, 2)
        };
        Pattern patternStruct = new("10,01", 1, 1);
        PatternTwo pattern = new PatternTwo(patternStruct);
        Assert.IsTrue(HelperTwo.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
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
        Pattern patternStruct = new("01,10,00,10", 1, 1);
        PatternTwo pattern = new PatternTwo(patternStruct);
        Assert.IsTrue(HelperTwo.CanPatternWork(playerHits, pattern.PatternTrueShapes[0], 0, 1));
    }
}