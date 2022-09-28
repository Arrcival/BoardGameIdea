using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;
using BoardGameIdea.Entities.One;

namespace BoardGameIdea.Tests.MultiTest;

public class MediumTest
{
    List<IGame> games;
    [SetUp]
    public void Setup()
    {
        Pattern[] patterns = new Pattern[5]{
            new("10,01", 1, 2),
            new("100,000,001", 2, 2),
            new("111,001", 3, 4),
            new("11,11", 2),
            new("1010,0001", 3, 4)
        };
        games = TestHelper.SetupGames(5, 10, false, patterns);
    }

    [Test]
    public void TestMediumFive1()
    {
        foreach (IGame game in games)
        {
            game.Play(0, 2);
            game.Play(2, 0);
            game.Play(1, 1);
            game.Play(3, 1);
            game.Play(2, 1);
            game.Play(3, 3);
            game.Play(3, 2);


            Assert.IsFalse(game.IsGameOver());
            Assert.That(game.WhiteScore, Is.EqualTo(2));
            Assert.That(game.BlackScore, Is.EqualTo(3));
        }
    }
    [Test]
    public void TestMediumFive1Bis()
    {
        foreach (IGame game in games)
        {
            game.SetupFromString("..w..,.w...,bw...,.bwb.,.....");

            Assert.IsFalse(game.IsGameOver());
            Assert.That(game.WhiteScore, Is.EqualTo(2));
            Assert.That(game.BlackScore, Is.EqualTo(3));
        }
    }

    [Test]
    public void TestMediumFive2()
    {
        foreach (IGame game in games)
        {
            game.SetupFromString("..w..,.w..b,.....,.wb..,.....");

            Assert.IsFalse(game.IsGameOver());
            Assert.That(game.WhiteScore, Is.EqualTo(3));
            Assert.That(game.BlackScore, Is.EqualTo(2));
        }
    }
    [Test]
    public void TestMediumFive3()
    {
        foreach (IGame game in games)
        {
            game.SetupFromString(".ww..,wwbb.,.bb..,ww...,.bb..");

            Assert.IsFalse(game.IsGameOver());
            Assert.That(game.WhiteScore, Is.EqualTo(6));
            Assert.That(game.BlackScore, Is.EqualTo(6));
        }
    }
}