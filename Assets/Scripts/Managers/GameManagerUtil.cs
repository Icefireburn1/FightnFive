using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
