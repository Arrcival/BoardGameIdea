using BoardGameIdea.Entities;
using static BoardGameIdea.Entities.HelperConst;
using static BoardGameIdea.Entities.HelperConst.TileType;

namespace BoardGameIdea.Tests.HelperTest;

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
        Assert.That(expectedReturnBoard, Is.EqualTo(Helper.RemovePattern(board, pattern, 0, 1)));
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
        Assert.That(expectedReturnBoard, Is.EqualTo(Helper.RemovePattern(board, pattern, 0, 1)));
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
        Assert.That(expectedReturnBoard, Is.EqualTo(Helper.RemovePattern(board, pattern, 0, 1)));
        Assert.That(expectedReturnBoard, !Is.EqualTo(board));
    }

}