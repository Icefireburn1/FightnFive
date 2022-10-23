using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameBoardManagerPlayModeTest
{
    GameObject go;
    GameBoardManager bm;

    [SetUp]
    [DebugLoggerEnablement(false)]
    public void Setup()
    {
        go = new GameObject();
        bm = go.AddComponent<GameBoardManager>();
    }

    [UnityTest]
    [DebugLoggerEnablement(false)]
    public IEnumerator TestGotoNextChapter()
    {
        yield return new WaitForSeconds(0.1f);

        GameManager.Chapter = 1;

        Assert.AreEqual(GameManager.Chapter, 1);

        bm.GotoNextChapter();

        Assert.AreEqual(GameManager.Chapter, 2);

        bm.GotoNextChapter();

        Assert.AreEqual(GameManager.Chapter, 3);

        bm.GotoNextChapter();

        Assert.AreEqual(GameManager.Chapter, 3);

    }

    [UnityTest]
    [DebugLoggerEnablement(false)]
    public IEnumerator TestGotoPrevChapter()
    {
        yield return new WaitForSeconds(0.1f);

        GameManager.Chapter = 3;

        Assert.AreEqual(GameManager.Chapter, 3);

        bm.GotoPrevChapter();

        Assert.AreEqual(GameManager.Chapter, 2);

        bm.GotoPrevChapter();

        Assert.AreEqual(GameManager.Chapter, 1);

        bm.GotoPrevChapter();

        Assert.AreEqual(GameManager.Chapter, 1);

    }

    [TearDown]
    public void TearDown()
    {
        GameObject.Destroy(go);
    }
}
