using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TurnOrderTests
{
    [Test]
    public void TestTurnOrderSize()
    {
        var turnOrder = new TurnOrder();
        Assert.AreEqual(turnOrder.Size(), 0);
        turnOrder.Add(new GameObject());
        Assert.AreEqual(turnOrder.Size(), 1);
    }

    [Test]
    public void TestAddToTurnOrder()
    {
        var turnOrder = new TurnOrder();
        turnOrder.Add(new GameObject());
        turnOrder.Add(new GameObject());
        turnOrder.Add(new GameObject());

        Assert.AreEqual(turnOrder.Size(), 3);
    }

    [Test]
    [DebugLoggerEnablement(false)]
    public void TestTurnOrderDoNextEmpty()
    {
        var turnOrder = new TurnOrder();

        Assert.IsNull(turnOrder.DoNext());
    }

    [Test]
    [DebugLoggerEnablement(false)]
    public void TestTurnOrderDoNextFilled()
    {
        var turnOrder = new TurnOrder();
        turnOrder.Add(new GameObject());

        Assert.IsNotNull(turnOrder.DoNext());
    }

    [Test]
    [DebugLoggerEnablement(false)]
    public void TestTurnOrderDoNextMovedToTop()
    {
        var turnOrder = new TurnOrder();
        var movedItem = new GameObject();
        turnOrder.Add(movedItem);
        turnOrder.Add(new GameObject());
        turnOrder.Add(new GameObject());
        turnOrder.DoNext();

        Assert.AreNotEqual(turnOrder.GetMoving(), movedItem);
        Assert.AreEqual(turnOrder.GetAllUnits()[turnOrder.Size() - 1], movedItem);
    }

    [Test]
    [DebugLoggerEnablement(false)]
    public void TestTurnOrderSortedBySpeed()
    {
        var turnOrder = new TurnOrder();
        var chara = new GameObject();
        chara.AddComponent<Hero>();

        chara.GetComponent<Hero>().Speed = 10;
        turnOrder.Add(chara);

        chara.GetComponent<Hero>().Speed = 15;
        turnOrder.Add(chara);

        chara.GetComponent<Hero>().Speed = 5;
        turnOrder.Add(chara);

        turnOrder.SortBySpeed();

        Assert.IsTrue(turnOrder.GetAllUnits()[0].GetComponent<Hero>().Speed >= turnOrder.GetAllUnits()[1].GetComponent<Hero>().Speed && turnOrder.GetAllUnits()[1].GetComponent<Hero>().Speed >= turnOrder.GetAllUnits()[2].GetComponent<Hero>().Speed);
    }
}
