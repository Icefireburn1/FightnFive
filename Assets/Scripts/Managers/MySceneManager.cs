using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Helper class that my buttons use to register their "onClick" functionality.
/// </summary>
public class MySceneManager : MonoBehaviour
{
    public void GotoScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SaveGame()
    {
        SaveLoad.SaveData();
        Debug.Log("Game saved");
    }

    public void LoadGame()
    {
        GameSaveData data = SaveLoad.LoadData();
        GameManager.CurrentFloorNumber = data.currentFloorNumber;
        GameManager.SetPlayerAttributes(data.characterAttack, data.characterHP, data.characterSpeed);
        Debug.Log("Game loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
