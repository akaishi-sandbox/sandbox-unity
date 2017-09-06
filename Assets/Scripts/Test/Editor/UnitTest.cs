using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NUnit.Framework;


[TestFixture]
[Category("Unit Test")]
public class UnitTest
{

    [Test]
    [Category("MathfTest")]
    public void MathfTest()
    {
        var c = Mathf.Cos(0);

        Assert.AreEqual(c, 1f, $"c0={c}");

        c = Mathf.Cos(Mathf.PI);
        Assert.AreEqual(c, 0f, $"c1={c}");   // 180?

        c = Mathf.Cos(2 * Mathf.PI);
        Assert.AreEqual(c, 1f, $"c2={c}");   // 360?
    }

    [Test]
    [Category("LinqTest")]
    public void LinqTest()
    {
        var data = new List<string>
        {
            string.Empty,
            "todo",
            "abatat",
            "rbaga",
        };

        data.ForEach(s => s = "update");

        // data.Where(s => s == "todo").ToList().ForEach(s => s = "update");

        // foreach (var s in data.Where(s => s == "todo"))
        // {
        //     s = "update"; // error CS1656: Cannot assign to `s' because it is a `foreach iteration variable'

        // }

        data[1] = "update";

        // data.ElementAtOrDefault(1) = "update";

        var update = data.Where(s => s == "update").FirstOrDefault();

        Assert.IsNotNull(update);
    }


    [Test]
    [Category("PropertyTest")]
    public void PropertyTest()
    {
        var p = new Property
        {
            NonPurchase = 10,
            Purchase = 8,
        };

        Assert.AreEqual(p.Value, 18);

        p -= 5;

        Assert.AreEqual(p.Value, 13);
        Assert.AreEqual(p.NonPurchase, 5);
        Assert.AreEqual(p.Purchase, 8);

        p -= 10;
        Assert.AreEqual(p.Value, 3);
        Assert.AreEqual(p.NonPurchase, 0);
        Assert.AreEqual(p.Purchase, 3);

        Assert.Throws<ArithmeticException>(() => p -= 5);

        Assert.AreEqual(p.Value, 3);

        p -= 3;
        Assert.AreEqual(p.Value, 0);

    }
}
