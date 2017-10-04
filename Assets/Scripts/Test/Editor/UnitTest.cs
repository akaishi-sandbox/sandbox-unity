using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NUnit.Framework;
using System.Linq;

[TestFixture]
[Category("Unit Test")]
internal class UnitTest
{
    struct TestDic
    {
        public string Code { get; set; }
        public int Count { get; set; }
    }

    [Test]
    [Category("FlatBuffersTest")]
    void FlatBuffersTest()
    {
        var fb = new FlatBuffers.FlatBufferBuilder(1);
        var name = fb.CreateString("abcd");
        var user = Data.User.CreateUser(fb, 10, name);

        Data.User.FinishUserBuffer(fb, user);

        var data = fb.SizedByteArray();
        var b = new FlatBuffers.ByteBuffer(data);

        Assert.IsTrue(Data.User.UserBufferHasIdentifier(b));

        var u = Data.User.GetRootAsUser(b);


        Assert.IsTrue(u.Id == 10);
        Assert.IsTrue(u.Name == "abcd");
    }

    [Test]
    [Category("DictionayTest")]
    void DictionaryTest()
    {

        var dic = new Dictionary<string, TestDic>
        {
            {"aaa", new TestDic{Code = "aaaCode", Count = 10}},
            {"bbb", new TestDic{Code = "bbbCode", Count = 20}},
        };

        Assert.AreEqual(dic["aaa"].Count, 10, "10?");

        var aaa = dic["aaa"];
        aaa.Count = 20;
        // dic["aaa"] = aaa;

        Assert.AreEqual(dic["aaa"].Count, 20, "20?");
    }

    [Test]
    [Category("MathfTest")]
    void MathfTest()
    {
        var c = Mathf.Cos(0);

        Assert.AreEqual(c, 1f, $"c0={c}");

        c = Mathf.Cos(Mathf.PI);
        Assert.AreEqual(c, -1f, $"c1={c}");   // 180?

        c = Mathf.Cos(2 * Mathf.PI);
        Assert.AreEqual(c, 1f, $"c2={c}");   // 360?
    }

    [Test]
    [Category("LinqTest")]
    void LinqTest()
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
    void PropertyTest()
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
