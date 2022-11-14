using BoardGameIdea.Entities;
using BoardGameIdea.Entities.Interfaces;
using BoardGameIdea.Entities.One;

namespace BoardGameIdea.Tests.MultiTest;

public class LargeTest
{
    List<IGame> games;
    [SetUp]
    public void Setup()
    {
        Pattern[] patterns = new Pattern[12]
        {
            new("101,000,101", 2, 1), // The square 
            new("1001,0000,0000,1001", 2, 1), // The big square 
            new("10001,00000,00000,00000,10001", 2, 1), // The really big square 
            new("100001,000000,000000,000000,000000,100001", 2, 1), // The biggest square 
            new("1111", 2, 2), // The line
            new("010,101,010", 2, 1), // The empty star
            new("010,111,010", 2, 1), // The full star
            new("00010,10000,00000,00001,01000", 3, 1), // The bended square
            new("010,001,100", 1, 4), // The small hook
            new("010,001,000,100", 1, 4), // The hook
            new("101,110,101", 2, 4), // The K
            new("011000,100000,000000,000000,000001,000110", 4, 2) // The mirror
        };
        games = TestHelper.SetupGames(7, 21, false, patterns);
    }

    [Test]
    public void TestLargeSeven()
    {
        foreach (IGame game in games)
        {
            game.SetupFromString("..wwbb.,.bwwbw.,.wbbbw.,.bbwwb.,..wbwb.,.wbwbb.,..wwbw.");

            Assert.IsFalse(game.IsGameOver());
            Assert.That(game.WhiteScore, Is.EqualTo(5));
            Assert.That(game.BlackScore, Is.EqualTo(3));
        }
    }
}