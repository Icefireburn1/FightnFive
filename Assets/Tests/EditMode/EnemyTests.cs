using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void EnemyTestsSimplePasses()
    {
        GameObject go = new();
        Enemy e = go.AddComponent<Enemy>();
        e.SetAttributes(4, 6, 8, new Vector3(1, 1, 1));
        Assert.AreEqual(4, e.Attack);
        Assert.AreEqual(6, e.Health);
        Assert.AreEqual(8, e.Speed);
        Assert.AreEqual(e.HealthBarPosition, new Vector3(1, 1, 1));
    }
}
