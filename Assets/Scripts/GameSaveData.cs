using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data that gets saved/loaded from a file.
/// If data is not found for an attribute, it defaults to int.MinValue;
/// </summary>
[System.Serializable]
public class GameSaveData
{
    public int currentFloorNumber = int.MinValue;
    public int characterHP = int.MinValue;
    public int characterAttack = int.MinValue;
    public int characterSpeed = int.MinValue;

    public GameSaveData(int currentFloorNumber, int characterHp, int characterAttack, int characterSpeed)
    {
        this.currentFloorNumber = currentFloorNumber;
        this.characterHP = characterHp;
        this.characterAttack = characterAttack;
        this.characterSpeed = characterSpeed;
    }
}
