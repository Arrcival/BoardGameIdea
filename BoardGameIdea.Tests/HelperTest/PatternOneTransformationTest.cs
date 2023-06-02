using BoardGameIdea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameIdea.Tests.HelperTest;

public class PatternOneTransformationTest
{
    [Test]
    public void TestBoolToIntConversion()
    {
        bool[,] test = new bool[,]
        {
            { true, false, false },
            { false, true, true }
        };
        (int, int)[] integers = test.GetTrueValues(3);
        Assert.That(integers[0].Item1, Is.EqualTo(0));
        Assert.That(integers[0].Item2, Is.EqualTo(0));
        Assert.That(integers[1].Item1, Is.EqualTo(1));
        Assert.That(integers[1].Item2, Is.EqualTo(1));
        Assert.That(integers[2].Item1, Is.EqualTo(1));
        Assert.That(integers[2].Item2, Is.EqualTo(2));
    }
    [Test]
    public void TestPatternConversion()
    {
        PatternBase patternStruct = new("100,011", 1, 2);
        Pattern pattern = new Pattern(patternStruct);
        Assert.That(pattern.PatternTrueShapes[0][0].Item1, Is.EqualTo(0));
        Assert.That(pattern.PatternTrueShapes[0][0].Item2, Is.EqualTo(0));
        Assert.That(pattern.PatternTrueShapes[0][1].Item1, Is.EqualTo(1));
        Assert.That(pattern.PatternTrueShapes[0][1].Item2, Is.EqualTo(1));
        Assert.That(pattern.PatternTrueShapes[0][2].Item1, Is.EqualTo(1));
        Assert.That(pattern.PatternTrueShapes[0][2].Item2, Is.EqualTo(2));
        Assert.That(pattern.PatternTrueShapes[1][0].Item1, Is.EqualTo(0));
        Assert.That(pattern.PatternTrueShapes[1][0].Item2, Is.EqualTo(1));
        Assert.That(pattern.PatternTrueShapes[1][1].Item1, Is.EqualTo(1));
        Assert.That(pattern.PatternTrueShapes[1][1].Item2, Is.EqualTo(0));
        Assert.That(pattern.PatternTrueShapes[1][2].Item1, Is.EqualTo(2));
        Assert.That(pattern.PatternTrueShapes[1][2].Item2, Is.EqualTo(0));
    }
}
