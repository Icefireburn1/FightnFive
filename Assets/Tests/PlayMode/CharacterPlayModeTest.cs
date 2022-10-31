using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CharacterPlayModeTest
{
    GameObject sam;
    GameObject jerry;
    GameObject charles;
    GameObject rogue;

    [SetUp]
    public void Setup()
    {
        sam = GameObject.Instantiate(Resources.Load("Prefabs/Characters/Sam")) as GameObject;
        jerry = GameObject.Instantiate(Resources.Load("Prefabs/Characters/Jerry")) as GameObject;
        charles = GameObject.Instantiate(Resources.Load("Prefabs/Characters/Charles")) as GameObject;
        rogue = GameObject.Instantiate(Resources.Load("Prefabs/Characters/Rogue")) as GameObject;
    }

    [UnityTest]
    public IEnumerator TestSamComesWithCharacterScript()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(sam.GetComponent<Character>());
    }

    [UnityTest]
    public IEnumerator TestCharlesComesWithCharacterScript()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(charles.GetComponent<Character>());
    }

    [UnityTest]
    public IEnumerator TestJerryComesWithCharacterScript()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(jerry.GetComponent<Character>());
    }

    [UnityTest]
    public IEnumerator TestRogueComesWithCharacterScript()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(rogue.GetComponent<Character>());
    }

    [UnityTest]
    public IEnumerator TestSamComesWithBoxCollider2D()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(sam.GetComponent<BoxCollider2D>());
    }

    [UnityTest]
    public IEnumerator TestJerryComesWithBoxCollider2D()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(charles.GetComponent<BoxCollider2D>());
    }

    [UnityTest]
    public IEnumerator TestCharlesComesWithBoxCollider2D()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(jerry.GetComponent<BoxCollider2D>());
    }

    [UnityTest]
    public IEnumerator TestRogueComesWithBoxCollider2D()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.NotNull(rogue.GetComponent<BoxCollider2D>());
    }

    [UnityTest]
    public IEnumerator TestCreateMarker()
    {
        yield return new WaitForSeconds(0.1f);

        sam.GetComponent<Character>().CreateMarker();
        var result = GameObject.FindGameObjectWithTag("Marker");
        Assert.IsNotNull(result);
    }

    [TearDown]
    public void TearDown()
    {
        GameObject.Destroy(sam);
        GameObject.Destroy(rogue);
        GameObject.Destroy(charles);
        GameObject.Destroy(jerry);
    }
}
