using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DoNotDestroyTests
{
    [UnityTest]
    public IEnumerator DoNotDestroyTestWithEnumeratorPasses()
    {
        yield return new WaitForSeconds(0.1f);

        GameObject go = new();
        go.AddComponent<DoNotDestroyUnique>();
        Assert.IsNotNull(go.GetComponent<DoNotDestroyUnique>());
    }
}
