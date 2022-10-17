using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to stop NullReferences when trying to load the game from the mainmenu.
/// Ideally, this should be fixed(?)
/// </summary>
public class CharacterInit : MonoBehaviour
{
    public GameObject sam;
    public GameObject charles;
    public GameObject rogue;
    public GameObject jerry;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            // Only need to check 1 to determine state of all
            if (GameManager.GetPlayerCharacter(GameManager.Heroes.Sam) == null)
            {
                GameManager.SetPlayerCharacter(GameManager.Heroes.Sam, sam);
                GameManager.SetPlayerCharacter(GameManager.Heroes.Jerry, jerry);
                GameManager.SetPlayerCharacter(GameManager.Heroes.Charles, charles);
                GameManager.SetPlayerCharacter(GameManager.Heroes.Rogue, rogue);
            }
            else
            {
                GameManager.HealPlayerCharacters();
            }
        }
        catch (NullReferenceException e)
        {
            Debug.LogError(e);
        }
    }
}
