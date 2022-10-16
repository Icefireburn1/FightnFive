using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for remembering information between scenes.
/// This allows other components to grab/set up-to-date information.
/// </summary>
public static class GameManager
{
    private static GameObject sam = null;
    private static GameObject jerry = null;
    private static GameObject charles = null;
    private static GameObject rogue = null;

    public static int Chapter { get => 1; set => Chapter = value; }
    public static Floors CurrentFloor { get; set; }
    public static int CurrentFloorNumber { get; set; }
    
    public enum Heroes
    {
        Sam,
        Jerry,
        Charles,
        Rogue
    }

    static GameManager()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        // TODO: Be able to load save file
        CurrentFloorNumber = 3;
    }

    public static void HealPlayerCharacters()
    {
        sam.GetComponent<Hero>().HealToFull();
        charles.GetComponent<Hero>().HealToFull();
        jerry.GetComponent<Hero>().HealToFull();
        rogue.GetComponent<Hero>().HealToFull();
    }

    public static GameObject GetPlayerCharacter(Heroes name)
    {
        switch (name)
        {
            case Heroes.Sam:
                return sam;

            case Heroes.Jerry:
                return jerry;

            case Heroes.Charles:
                return charles;

            case Heroes.Rogue:
                return rogue;
                
            default:
                Debug.LogError("Error getting player character in GameManager");
                return null;
        }
    }

    public static void SetPlayerCharacter(Heroes name, GameObject go)
    {
        go.SetActive(true);
        switch (name)
        {
            case Heroes.Sam:
                if (sam == null) sam = go;
                break;
            case Heroes.Jerry:
                if (jerry == null) jerry = go;
                break;
            case Heroes.Charles:
                if (charles == null) charles = go;
                break;
            case Heroes.Rogue:
                if (rogue == null) rogue = go;
                break;
            default:
                Debug.LogError("Error setting player character in GameManager");
                break;
        }
    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sam == null)
            return;

        if (scene.buildIndex == 2)
        {
            SetVisiblity(sam, true);
            SetVisiblity(jerry, true);
            SetVisiblity(rogue, true);
            SetVisiblity(charles, true);
        }
        else
        {
            SetVisiblity(sam, false);
            SetVisiblity(jerry, false);
            SetVisiblity(rogue, false);
            SetVisiblity(charles, false);
        }
    }

    static void SetVisiblity(GameObject go, bool value)
    {
        go.GetComponent<SpriteRenderer>().enabled = value;
    }
}
