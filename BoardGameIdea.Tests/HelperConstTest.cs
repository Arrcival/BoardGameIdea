using BoardGameIdea.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameIdea.Tests;

public class HelperConstTest
{
    [Test]
    public void TestAllCombosInt()
    {
        var entry = new List<int>() { 1, 2, 3 };
        var result = HelperConst.GetAllCombos(entry);

        Assert.That(result, Has.Count.EqualTo(7));
        Assert.That(result, Does.Contain(new List<int>() { 1 }));
        Assert.That(result, Does.Contain(new List<int>() { 2 }));
        Assert.That(result, Does.Contain(new List<int>() { 3 }));
        Assert.That(result, Does.Contain(new List<int>() { 2, 3 }));
        Assert.That(result, Does.Contain(new List<int>() { 1, 3 }));
        Assert.That(result, Does.Contain(new List<int>() { 1, 2 }));
        Assert.That(result, Does.Contain(new List<int>() { 1, 2, 3 }));
    }
    [Test]
    public void TestAllCombosStringCountFour()
    {
        var entry = new List<string>();
        for (int i = 0; i < 4; i++)
            entry.Add("word");
        var result = HelperConst.GetAllCombos(entry);

        Assert.That(result, Has.Count.EqualTo(15));
    }

    [Test]
    public void TestAllCombosStringCountFive()
    {
        var entry = new List<string>();
        for (int i = 0; i < 5; i++)
            entry.Add("word");
        var result = HelperConst.GetAllCombos(entry);

        Assert.That(result, Has.Count.EqualTo(31));
    }

}
