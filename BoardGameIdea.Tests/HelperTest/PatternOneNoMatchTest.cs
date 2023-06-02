using BoardGameIdea.Entities;
using static BoardGameIdea.Entities.HelperConst;
using static BoardGameIdea.Entities.HelperConst.TileType;

namespace BoardGameIdea.Tests.HelperTest;

public class PatternOneNoMatchTest
{
    [Test]
    public void TestPatternNoMatchOne()
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
        Assert.IsFalse(Helper.CanPatternWork(board, pattern, 0, 1, WHITE));
    }

    [Test]
    public void TestPatternOOB1()
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
        Assert.IsFalse(Helper.CanPatternWork(board, pattern, 0, 2, WHITE));
    }
    [Test]
    public void TestPatternOOB2()
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
        Assert.IsFalse(Helper.CanPatternWork(board, pattern, 0, 3, WHITE));
    }
    [Test]
    public void TestPatternOOB3()
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
        Assert.IsFalse(Helper.CanPatternWork(board, pattern, -1, 0, WHITE));
    }
}