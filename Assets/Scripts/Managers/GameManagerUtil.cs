using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Useful for viewing information while playing within Editor.
/// Otherwise, this is useless.
/// </summary>
public class GameManagerUtil : MonoBehaviour
{
    public GameObject sam;
    public GameObject rogue;
    public GameObject charles;
    public GameObject jerry;

    public void Update()
    {
        UpdateInfoFromManager();
    }

    public void UpdateInfoFromManager()
    {
        sam = GameManager.GetPlayerCharacter(GameManager.Heroes.Sam);
        jerry = GameManager.GetPlayerCharacter(GameManager.Heroes.Jerry);
        charles = GameManager.GetPlayerCharacter(GameManager.Heroes.Charles);
        rogue = GameManager.GetPlayerCharacter(GameManager.Heroes.Rogue);
    }
}
