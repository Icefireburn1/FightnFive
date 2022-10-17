using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
