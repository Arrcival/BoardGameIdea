using BoardGameIdea.Entities.One;

namespace BoardGameIdea.Tests.GameTest;

public class BasicTest
{
    GameOne currentGame;
    [SetUp]
    public void Setup()
    {
        currentGame = new GameOne(3, 3, false);
        Pattern pattern1 = new("11", 1, 2);
        Pattern pattern2 = new("100,000,001", 7, 2);
        Pattern pattern3 = new("11,01", 5, 4);
        currentGame.SetupPatterns(pattern1, pattern2, pattern3);
    }

    [Test]
    public void TestBasicThree1()
    {
        Assert.IsFalse(currentGame.IsGameOver());
        currentGame.Play(0, 0);
        currentGame.Play(2, 2);
        currentGame.Play(0, 1);
        Assert.IsFalse(currentGame.IsGameOver());
        currentGame.Play(0, 2);
        Assert.IsFalse(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(1));
        Assert.That(currentGame.BlackScore, Is.EqualTo(0));
    }
    [Test]
    public void TestBasicThree2()
    {
        Assert.IsFalse(currentGame.IsGameOver());
        currentGame.Play(0, 0);
        currentGame.Play(2, 1);
        currentGame.Play(2, 2);
        Assert.IsFalse(currentGame.IsGameOver());
        currentGame.Play(0, 1);
        Assert.IsFalse(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(7));
        Assert.That(currentGame.BlackScore, Is.EqualTo(0));
    }
    [Test]
    public void TestBasicThree3()
    {
        currentGame.Play(0, 1);
        currentGame.Play(2, 0);
        currentGame.Play(1, 1);
        currentGame.Play(2, 1);
        currentGame.Play(1, 2);
        currentGame.Play(2, 2);

        Assert.IsTrue(currentGame.IsGameOver());
        Assert.That(currentGame.WhiteScore, Is.EqualTo(5));
        Assert.That(currentGame.BlackScore, Is.EqualTo(1));
    }
}