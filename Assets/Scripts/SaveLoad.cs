using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Manages our save/load system. Saves a file at "safe" location.
/// For example this saves 'Game.save' at C:\Users\Justin\AppData\LocalLow\DefaultCompany\FightnFive for me.
/// </summary>
public static class SaveLoad
{
    readonly static string PATH = Application.persistentDataPath + "/Game.save";

    public static void SaveData()
    {
        if (GameManager.GetPlayerCharacter(GameManager.Heroes.Sam) == null)
            return;

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(PATH, FileMode.Create);

        var playerChar = GameManager.GetPlayerCharacter(GameManager.Heroes.Sam).GetComponent<Character>();
        GameSaveData gameData = new GameSaveData(GameManager.CurrentFloorNumber, playerChar.Health, playerChar.Attack, playerChar.Speed);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static bool SaveFileExists()
    {
        return File.Exists(PATH);
    }

    public static GameSaveData LoadData()
    {
        if (SaveFileExists())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(PATH, FileMode.Open);

            GameSaveData data = formatter.Deserialize(stream) as GameSaveData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + PATH);
            return null;
        }
    }
}
