using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests;

public class RotationTest
{
    [Test]
    public void TestRotationSquare()
    {
        bool[,] testArray = new bool[,] { { true, false }, { false, true } };

        testArray = testArray.RotateArrayClockwise();
        Assert.IsFalse(testArray[0, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsTrue(testArray[0, 1]);
        Assert.IsTrue(testArray[1, 0]);
        testArray = testArray.RotateArrayClockwise();
        Assert.IsTrue(testArray[0, 0]);
        Assert.IsTrue(testArray[1, 1]);
        Assert.IsFalse(testArray[0, 1]);
        Assert.IsFalse(testArray[1, 0]);

    }

    [Test]
    public void TestRotationRectangle()
    {
        bool[,] testArray = new bool[,] { { true, false, false }, { false, false, true } };

        testArray = testArray.RotateArrayClockwise();
        Assert.IsFalse(testArray[0, 0]);
        Assert.IsTrue(testArray[0, 1]);
        Assert.IsFalse(testArray[1, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsTrue(testArray[2, 0]);
        Assert.IsFalse(testArray[2, 1]);
        testArray = testArray.RotateArrayClockwise();
        Assert.IsTrue(testArray[0, 0]);
        Assert.IsFalse(testArray[0, 1]);
        Assert.IsFalse(testArray[0, 2]);
        Assert.IsFalse(testArray[1, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsTrue(testArray[1, 2]);
    }

    [Test]
    public void TestRotationRectangleTwo()
    {
        bool[,] testArray = new bool[,] { { true, false, false }, { false, true, false } };

        testArray = testArray.RotateArrayClockwise();
        Assert.IsFalse(testArray[0, 0]);
        Assert.IsTrue(testArray[0, 1]);
        Assert.IsTrue(testArray[1, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsFalse(testArray[2, 0]);
        Assert.IsFalse(testArray[2, 1]);
        testArray = testArray.RotateArrayClockwise();
        Assert.IsFalse(testArray[0, 0]);
        Assert.IsTrue(testArray[0, 1]);
        Assert.IsFalse(testArray[0, 2]);
        Assert.IsFalse(testArray[1, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsTrue(testArray[1, 2]);
    }

    [Test]
    public void TestRotationHorizontalLine()
    {
        bool[,] testArray = new bool[,] { { true, false, false, false } };

        testArray = testArray.RotateArrayClockwise();
        Assert.IsTrue(testArray[0, 0]);
        Assert.IsFalse(testArray[1, 0]);
        Assert.IsFalse(testArray[2, 0]);
        Assert.IsFalse(testArray[3, 0]);
    }

    [Test]
    public void TestRotationVerticalLine()
    {
        bool[,] testArray = new bool[,] { { true }, { false }, { false }, { false } };

        testArray = testArray.RotateArrayClockwise();
        Assert.IsFalse(testArray[0, 0]);
        Assert.IsFalse(testArray[0, 1]);
        Assert.IsFalse(testArray[0, 2]);
        Assert.IsTrue(testArray[0, 3]);
    }

    [Test]
    public void TestRotationWeirdPattern()
    {
        bool[,] testArray = new bool[,] { { false, true }, { true, false }, { false, false }, { true, false } };

        testArray = testArray.RotateArrayClockwise();
        Assert.IsTrue(testArray[0, 0]);
        Assert.IsFalse(testArray[0, 1]);
        Assert.IsTrue(testArray[0, 2]);
        Assert.IsFalse(testArray[0, 3]);
        Assert.IsFalse(testArray[1, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsFalse(testArray[1, 2]);
        Assert.IsTrue(testArray[1, 3]);
        testArray = testArray.RotateArrayClockwise();
        Assert.IsFalse(testArray[0, 0]);
        Assert.IsTrue(testArray[0, 1]);
        Assert.IsFalse(testArray[1, 0]);
        Assert.IsFalse(testArray[1, 1]);
        Assert.IsFalse(testArray[2, 0]);
        Assert.IsTrue(testArray[2, 1]);
        Assert.IsTrue(testArray[3, 0]);
        Assert.IsFalse(testArray[3, 1]);
    }
}