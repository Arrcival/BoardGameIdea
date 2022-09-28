using BoardGameIdea.Entities;
using BoardGameIdea.Entities.One;

namespace BoardGameIdea.Tests;

public class PatternTest
{
    [Test]
    public void TestLoadBasicPatterns()
    {
        Pattern aPattern = new("10", 1, 1);
        bool[,] expectedArray = new bool[,] { { true, false } };
        Assert.That(aPattern.ToBoolArray(), Is.EqualTo(expectedArray));

        aPattern = new("01", 1, 1);
        expectedArray = new bool[,] { { false, true } };
        Assert.That(aPattern.ToBoolArray(), Is.EqualTo(expectedArray));

        aPattern = new("10,10", 1, 1);
        expectedArray = new bool[,] { { true, false }, { true, false } };
        Assert.That(aPattern.ToBoolArray(), Is.EqualTo(expectedArray));

        aPattern = new("1,1,1,1", 1, 1);
        expectedArray = new bool[,] { { true }, { true }, { true }, { true }};
        Assert.That(aPattern.ToBoolArray(), Is.EqualTo(expectedArray));
    }

    [Test]
    public void TestGetPatternsSimples()
    {
        Pattern aPattern = new("10", 1, 1);
        Assert.That(aPattern.Rotations, Is.EqualTo(1));

        aPattern = new("10", 1, 4);
        Assert.That(aPattern.Rotations, Is.EqualTo(4));
    }
}
