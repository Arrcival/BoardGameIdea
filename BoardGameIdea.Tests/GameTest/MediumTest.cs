using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;

namespace BoardGameIdea.Tests;

public class MediumTest
{
    IGame game;
    [SetUp]
    public void Setup()
    {
        PatternBase[] patterns = new PatternBase[5]{
            new("10,01", 1, 2),
            new("100,000,001", 2, 2),
            new("111,001", 3, 4),
            new("11,11", 2),
            new("1010,0001", 3, 4)
        };
        game = TestHelper.SetupGame(5, 10, false, patterns);
    }

    [Test]
    public void TestMediumFive1()
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

    [Test]
    public void TestMediumFive1Bis()
    {
        game.SetupFromString("..w..,.w...,bw...,.bwb.,.....");

        Assert.IsFalse(game.IsGameOver());
        Assert.That(game.WhiteScore, Is.EqualTo(2));
        Assert.That(game.BlackScore, Is.EqualTo(3));
    }

    [Test]
    public void TestMediumFive2()
    {
        game.SetupFromString("..w..,.w..b,.....,.wb..,.....");

        Assert.IsFalse(game.IsGameOver());
        Assert.That(game.WhiteScore, Is.EqualTo(3));
        Assert.That(game.BlackScore, Is.EqualTo(2));
    }
    [Test]
    public void TestMediumFive3()
    {
        game.SetupFromString(".ww..,wwbb.,.bb..,ww...,.bb..");
        /* .ww..
         * wwbb.
         * .bb..
         * ww...
         * .bb..
         */

        Assert.IsFalse(game.IsGameOver());
        Assert.That(game.WhiteScore, Is.EqualTo(6));
        Assert.That(game.BlackScore, Is.EqualTo(6));
    }
}