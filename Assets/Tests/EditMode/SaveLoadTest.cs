using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SaveLoadTest
{
    [Test]
    public void TestFileExists()
    {
        Assert.IsTrue(SaveLoad.SaveFileExists());
    }
}
