using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data that gets saved/loaded from a file
/// </summary>
[System.Serializable]
public class GameSaveData
{
    public int currentFloorNumber;
    public int characterHP;
    public int characterAttack;
    public int characterSpeed;

    public GameSaveData(int currentFloorNumber, int characterHp, int characterAttack, int characterSpeed)
    {
        this.currentFloorNumber = currentFloorNumber;
        this.characterHP = characterHp;
        this.characterAttack = characterAttack;
        this.characterSpeed = characterSpeed;
    }
}
