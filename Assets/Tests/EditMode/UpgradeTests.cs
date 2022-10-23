using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UpgradeTests
{
    [Test]
    public void TestUpgradeNotNegative()
    {
        GameManager.NumberUpgradesAvailable = 0;
        GameManager.NumberUpgradesAvailable--;
        GameManager.NumberUpgradesAvailable--;
        Assert.AreEqual(GameManager.NumberUpgradesAvailable, 0);
    }

    [Test]
    public void TestUpgradeIncrements()
    {
        GameManager.NumberUpgradesAvailable = 0;
        Assert.AreEqual(GameManager.NumberUpgradesAvailable, 0);

        GameManager.NumberUpgradesAvailable++;
        Assert.AreEqual(GameManager.NumberUpgradesAvailable, 1);

        GameManager.NumberUpgradesAvailable += 5;
        Assert.AreEqual(GameManager.NumberUpgradesAvailable, 6);
    }
}
