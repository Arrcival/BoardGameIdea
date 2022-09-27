using BoardGameIdea.Entities;

namespace BoardGameIdea.Tests.GameTest;

public class MediumTest
{
    GameOne currentGame;
    [SetUp]
    public void Setup()
    {
        currentGame = new GameOne(5, 10, false);
        Pattern[] patterns = new Pattern[5]{
            new("10,01", 1, 2),
            new("100,000,001", 2, 2),
            new("111,001", 3, 4),
            new("11,11", 2),
            new("1010,0001", 3, 4)
        };
        currentGame.SetupPatterns(patterns);
    }

    [Test]
    public void TestMediumFive1()
    {
        currentGame.Play(0, 2);
        currentGame.Play(2, 0);
        currentGame.Play(1, 1);
        currentGame.Play(3, 1);
        currentGame.Play(2, 1);
        currentGame.Play(3, 3);
        currentGame.Play(3, 2);


        Assert.IsFalse(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(2));
        Assert.That(currentGame.BlackScore, Is.EqualTo(3));
    }
    [Test]
    public void TestMediumFive1Bis()
    {
        currentGame.SetupFromString("..w..,.w...,bw...,.bwb.,.....");

        Assert.IsFalse(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(2));
        Assert.That(currentGame.BlackScore, Is.EqualTo(3));
    }

    [Test]
    public void TestMediumFive2()
    {
        currentGame.SetupFromString("..w..,.w..b,.....,.wb..,.....");

        Assert.IsFalse(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(3));
        Assert.That(currentGame.BlackScore, Is.EqualTo(2));
    }
    [Test]
    public void TestMediumFive3()
    {
        currentGame.SetupFromString(".ww..,wwbb.,.bb..,ww...,.bb..");

        Assert.IsFalse(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(6));
        Assert.That(currentGame.BlackScore, Is.EqualTo(6));
    }
}