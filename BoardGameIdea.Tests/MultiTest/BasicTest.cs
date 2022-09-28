using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;
using BoardGameIdea.Entities.One;

namespace BoardGameIdea.Tests.MultiTest;

public class BasicTest
{
    List<IGame> games;
    [SetUp]
    public void Setup()
    {
        Pattern pattern1 = new("11", 1, 2);
        Pattern pattern2 = new("100,000,001", 7, 2);
        Pattern pattern3 = new("11,01", 5, 4);
        games = TestHelper.SetupGames(3, 3, false, pattern1, pattern2, pattern3);
    }

    [Test]
    public void TestBasicThree1()
    {
        foreach (IGame game in games)
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
    }
    [Test]
    public void TestBasicThree2()
    {
        foreach (IGame game in games)
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
    }
    [Test]
    public void TestBasicThree3()
    {
            foreach (IGame game in games)
            {
                game.Play(0, 1);
                game.Play(2, 0);
                game.Play(1, 1);
                game.Play(2, 1);
                game.Play(1, 2);
                game.Play(2, 2);

                Assert.IsTrue(game.IsGameOver());
                Assert.That(game.WhiteScore, Is.EqualTo(5));
                Assert.That(game.BlackScore, Is.EqualTo(1));
            }
    }
}