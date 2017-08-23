using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NUnit.Framework;


[TestFixture]
[Category("Unit Test")]
public class UnitTest
{

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
