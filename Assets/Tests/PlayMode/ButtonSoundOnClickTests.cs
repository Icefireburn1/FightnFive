using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ButtonSoundOnClickTests
{
    [UnityTest]
    public IEnumerator TestHasButtonComponent()
    {
        yield return new WaitForSeconds(0.1f);

        GameObject go = new();
        go.AddComponent<ButtonSoundOnClick>();
        Assert.IsNotNull(go.GetComponent<ButtonSoundOnClick>());
    }
}
