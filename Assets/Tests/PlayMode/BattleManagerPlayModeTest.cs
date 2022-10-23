using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BattleManagerPlayModeTest
{
    GameObject bm;

    [SetUp]
    public void Setup()
    {
        bm = new GameObject();
    }

    [UnityTest]
    public IEnumerator TestBattleManagerNoError()
    {
        yield return new WaitForSeconds(1f);

        bm.AddComponent<BattleManager>();
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.Destroy(bm);
    }
}
