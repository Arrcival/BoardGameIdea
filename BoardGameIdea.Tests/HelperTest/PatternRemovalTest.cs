using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests.HelperTest;

public class PatternRemovalBisTest
{
    [Test]
    public void TestPatternRemoval1()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        List<(int, int)> expectedPlayerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        PatternBase patternStruct = new("1", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        List<(int, int)> newPlayerHits = Helper.RemovePattern(playerHits, pattern.PatternTrueShapes[0], 0, 1);
        Assert.That(expectedPlayerHits, Is.EqualTo(newPlayerHits));
        Assert.IsFalse(playerHits == newPlayerHits);
    }
    [Test]
    public void TestPatternRemoval2()
    {
        List<(int, int)> playerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        List<(int, int)> expectedPlayerHits = new()
        {
            (1, 0),
            (1, 2)
        };
        PatternBase patternStruct = new("11", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        List<(int, int)> newPlayerHits = Helper.RemovePattern(playerHits, pattern.PatternTrueShapes[0], 0, 1);
        Assert.That(expectedPlayerHits, Is.EqualTo(newPlayerHits));
        Assert.IsFalse(playerHits == newPlayerHits);
    }
    [Test]
    public void TestPatternRemoval3()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (0, 2)
        };
        List<(int, int)> expectedPlayerHits = new();
        PatternBase patternStruct = new("11", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        List<(int, int)> newPlayerHits = Helper.RemovePattern(playerHits, pattern.PatternTrueShapes[0], 0, 1);
        Assert.That(expectedPlayerHits, Is.EqualTo(newPlayerHits));
        Assert.That(newPlayerHits, !Is.EqualTo(playerHits));
        Assert.IsFalse(playerHits == newPlayerHits);
    }

    [Test]
    public void TestPatternRemovalBig()
    {
        List<(int, int)> playerHits = new()
        {
            (0, 1),
            (0, 2),
            (1, 0),
            (1, 2),
            (2, 2),
            (2, 3)
        };
        List<(int, int)> expectedPlayerHits = new();
        PatternBase patternStruct = new("0110,1010,0011", 1, 1);
        Pattern pattern = new Pattern(patternStruct);
        List<(int, int)> newPlayerHits = Helper.RemovePattern(playerHits, pattern.PatternTrueShapes[0], 0, 0);
        Assert.That(expectedPlayerHits, Is.EqualTo(newPlayerHits));
        Assert.That(newPlayerHits, !Is.EqualTo(playerHits));
        Assert.IsFalse(playerHits == newPlayerHits);
    }

}