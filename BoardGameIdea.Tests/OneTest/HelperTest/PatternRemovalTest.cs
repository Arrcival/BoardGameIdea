using BoardGameIdea.Entities;
using BoardGameIdea.Entities.One;
using static BoardGameIdea.Entities.Helper;
using static BoardGameIdea.Entities.Helper.TileType;

namespace BoardGameIdea.Tests.OneTest.HelperTest;

public class PatternRemovalTest
{
    [Test]
    public void TestPatternRemoval1()
    {
        TileType[,] board = new TileType[,]
        {
            { EMPTY, BLACK, BLACK },
            { WHITE, EMPTY, WHITE }
        };
        bool[,] pattern = new bool[,]
        {
            { true }
        };
        TileType[,] expectedReturnBoard = new TileType[,]
        {
            { EMPTY, EMPTY, BLACK },
            { WHITE, EMPTY, WHITE }
        };
        Assert.That(expectedReturnBoard, Is.EqualTo(HelperOne.RemovePattern(board, pattern, 0, 1)));
        Assert.That(expectedReturnBoard, !Is.EqualTo(board));
    }
    [Test]
    public void TestPatternRemoval2()
    {
        TileType[,] board = new TileType[,]
        {
            { EMPTY, BLACK, BLACK },
            { WHITE, EMPTY, WHITE }
        };
        bool[,] pattern = new bool[,]
        {
            { true, true }
        };
        TileType[,] expectedReturnBoard = new TileType[,]
        {
            { EMPTY, EMPTY, EMPTY },
            { WHITE, EMPTY, WHITE }
        };
        Assert.That(expectedReturnBoard, Is.EqualTo(HelperOne.RemovePattern(board, pattern, 0, 1)));
        Assert.That(expectedReturnBoard, !Is.EqualTo(board));
    }
    [Test]
    public void TestPatternRemoval3()
    {
        TileType[,] board = new TileType[,]
        {
            { EMPTY, BLACK, BLACK },
            { WHITE, EMPTY, WHITE }
        };
        bool[,] pattern = new bool[,]
        {
            { true, false },
            { true, true }
        };
        TileType[,] expectedReturnBoard = new TileType[,]
        {
            { EMPTY, EMPTY, BLACK },
            { WHITE, EMPTY, EMPTY }
        };
        Assert.That(expectedReturnBoard, Is.EqualTo(HelperOne.RemovePattern(board, pattern, 0, 1)));
        Assert.That(expectedReturnBoard, !Is.EqualTo(board));
    }

}