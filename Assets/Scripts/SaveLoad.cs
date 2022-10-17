using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData()
    {
        if (GameManager.GetPlayerCharacter(GameManager.Heroes.Sam) == null)
            return;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Game.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        var playerChar = GameManager.GetPlayerCharacter(GameManager.Heroes.Sam).GetComponent<Character>();
        GameSaveData gameData = new GameSaveData(GameManager.CurrentFloorNumber, playerChar.Health, playerChar.Attack, playerChar.Speed);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameSaveData LoadData()
    {
        string path = Application.persistentDataPath + "/Game.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameSaveData data = formatter.Deserialize(stream) as GameSaveData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}
