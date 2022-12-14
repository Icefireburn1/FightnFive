using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for remembering information between scenes.
/// This allows other components to grab/set up-to-date information.
/// If a component exists, chances are they are using this object.
/// </summary>
public static class GameManager
{
    private static GameObject sam = null;
    private static GameObject jerry = null;
    private static GameObject charles = null;
    private static GameObject rogue = null;
    private static int numberUpgradesAvailable;

    public static int Chapter { get; set; }
    public static Floors CurrentFloor { get; set; } // The floor that the player is challenging
    public static int CurrentFloorNumber { get; set; }  // This is the floor that the player needs to clear to progress
    public static int CurrentlyChallengingFloorNumber { get; set; } // The current floor that the player is battling
    public static int NumberUpgradesAvailable
    { 
        get
        {
            return numberUpgradesAvailable;
        }
        set
        {
            if (value >= 0)
            {
                numberUpgradesAvailable = value;
            }
        }
    }
    
    public enum Heroes
    {
        Sam,
        Jerry,
        Charles,
        Rogue
    }

    /// <summary>
    /// Increment highest game floor (and chapter if needed).
    /// Takes player to game victory screen if past highest chapter.
    /// </summary>
    public static void NextGameFloor()
    {
        NumberUpgradesAvailable++;
        CurrentFloorNumber++;
        Chapter = (int)Mathf.Ceil((float)CurrentFloorNumber / 5f);
        if (CurrentFloorNumber > 15)
        {
            SceneManager.LoadScene(6);
        }
    }

    static GameManager()
    {
        NumberUpgradesAvailable = 0;
        SceneManager.sceneLoaded += OnSceneLoaded;
        Chapter = 1;
        CurrentFloorNumber = 1;
    }

    /// <summary>
    /// Helper function to fully heal all player characters
    /// </summary>
    public static void HealPlayerCharacters()
    {
        sam.GetComponent<Hero>().HealToFull();
        charles.GetComponent<Hero>().HealToFull();
        jerry.GetComponent<Hero>().HealToFull();
        rogue.GetComponent<Hero>().HealToFull();
    }

    /// <summary>
    /// Helper function to grab a character from this persistent object
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Updates the character that is stored in this persistent object
    /// </summary>
    /// <param name="name"></param>
    /// <param name="go"></param>
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

    /// <summary>
    /// Set attributes when transitioning scenes.
    /// </summary>
    /// <param name="scene">The scene we went to.</param>
    /// <param name="mode">Extra info.</param>
    static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sam == null)
            return;

        // Battle Scene
        if (scene.buildIndex == 2)
        {
            SetVisiblity(sam, true);
            SetVisiblity(jerry, true);
            SetVisiblity(rogue, true);
            SetVisiblity(charles, true);

            SetColliderActive(sam, true);
            SetColliderActive(jerry, true);
            SetColliderActive(rogue, true);
            SetColliderActive(charles, true);
        }
        else
        {
            SetVisiblity(sam, false);
            SetVisiblity(jerry, false);
            SetVisiblity(rogue, false);
            SetVisiblity(charles, false);
        }
    }

    /// <summary>
    /// Set object sprite visiblity
    /// </summary>
    /// <param name="go"></param>
    /// <param name="value"></param>
    static void SetVisiblity(GameObject go, bool value)
    {
        go.GetComponent<SpriteRenderer>().enabled = value;
    }

    /// <summary>
    /// Set collider enabled
    /// </summary>
    /// <param name="go"></param>
    /// <param name="value"></param>
    static void SetColliderActive(GameObject go, bool value)
    {
        go.GetComponent<BoxCollider2D>().enabled = value;
    }

    /// <summary>
    /// Apply attack, health, and speed to player characters
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="health"></param>
    /// <param name="speed"></param>
    public static void SetPlayerAttributes(int attack, int health, int speed)
    {
        var samGO = sam.GetComponent<Character>();
        var rogueGO = rogue.GetComponent<Character>();
        var jerryGO = jerry.GetComponent<Character>();
        var charlesGO = charles.GetComponent<Character>();

        samGO.Attack = attack;
        rogueGO.Attack = attack;
        jerryGO.Attack = attack;
        charlesGO.Attack = attack;

        samGO.Health = health;
        rogueGO.Health = health;
        jerryGO.Health = health;
        charlesGO.Health = health;

        samGO.Speed = speed;
        rogueGO.Speed = speed;
        jerryGO.Speed = speed;
        charlesGO.Speed = speed;
    }
}
