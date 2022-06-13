using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests;

public class PatternTest
{
    [Test]
    public void TestLoadBasicPatterns()
    {
        Pattern aPattern = new("10", 1, 1);
        bool[,] expectedArray = new bool[,] { { true, false } };
        Assert.That(aPattern.PatternShape, Is.EqualTo(expectedArray));
        Assert.That(aPattern.TilesAmount, Is.EqualTo(1));

        aPattern = new("01", 1, 1);
        expectedArray = new bool[,] { { false, true } };
        Assert.That(aPattern.PatternShape, Is.EqualTo(expectedArray));
        Assert.That(aPattern.TilesAmount, Is.EqualTo(1));

        aPattern = new("10,10", 1, 1);
        expectedArray = new bool[,] { { true, false }, { true, false } };
        Assert.That(aPattern.PatternShape, Is.EqualTo(expectedArray));
        Assert.That(aPattern.TilesAmount, Is.EqualTo(2));

        aPattern = new("1,1,1,1", 1, 1);
        expectedArray = new bool[,] { { true }, { true }, { true }, { true }};
        Assert.That(aPattern.PatternShape, Is.EqualTo(expectedArray));
        Assert.That(aPattern.TilesAmount, Is.EqualTo(4));
    }

    [Test]
    public void TestGetPatternsSimples()
    {
        Pattern aPattern = new("10", 1, 1);
        Assert.That(aPattern.PatternShapes.Length, Is.EqualTo(1));
        Assert.That(aPattern.TilesAmount, Is.EqualTo(1));

        aPattern = new("10", 1, 4);
        Assert.That(aPattern.PatternShapes.Length, Is.EqualTo(4));
        Assert.That(aPattern.TilesAmount, Is.EqualTo(1));
    }
}
