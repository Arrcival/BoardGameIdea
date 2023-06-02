using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;

namespace BoardGameIdea.Tests;

public class BasicOverlapTest
{
    IGame game;
    [SetUp]
    public void Setup()
    {
        PatternBase pattern1 = new("11", 1, 2);
        PatternBase pattern2 = new("100,000,001", 7, 2);
        PatternBase pattern3 = new("11,01", 5, 4);
        game = TestHelper.SetupGame(3, 3, true, pattern1, pattern2, pattern3);
    }

    [Test]
    public void TestBasicThree1()
    {
        Assert.IsFalse(game.IsGameOver());
        game.Play(0, 0);
        game.Play(2, 2);
        game.Play(0, 1);
        Assert.IsFalse(game.IsGameOver());
        game.Play(0, 2);
        Assert.IsFalse(game.IsGameOver());
        Assert.That(game.WhiteScore, Is.EqualTo(1));
        Assert.That(game.BlackScore, Is.EqualTo(0));

    }
    [Test]
    public void TestBasicThree2()
    {
        Assert.IsFalse(game.IsGameOver());
        game.Play(0, 0);
        game.Play(2, 1);
        game.Play(2, 2);
        Assert.IsFalse(game.IsGameOver());
        game.Play(0, 1);
        Assert.IsFalse(game.IsGameOver());
        Assert.That(game.WhiteScore, Is.EqualTo(7));
        Assert.That(game.BlackScore, Is.EqualTo(0));

    }
    [Test]
    public void TestBasicThree3()
    {
        game.Play(0, 1);
        game.Play(2, 0);
        game.Play(1, 1);
        game.Play(2, 1);
        game.Play(1, 2);
        game.Play(2, 2);

        Assert.IsTrue(game.IsGameOver());
        Assert.That(game.WhiteScore, Is.EqualTo(7));
        Assert.That(game.BlackScore, Is.EqualTo(2));

    }
}