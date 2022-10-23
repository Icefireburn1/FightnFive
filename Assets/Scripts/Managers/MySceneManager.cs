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
        RunAllSaves();
    }

    void RunAllSaves()
    {
        PlayerPrefs.SetInt("numUpgrades", GameManager.NumberUpgradesAvailable);
        PlayerPrefs.SetInt("samBonusAttack", GameManager.GetPlayerCharacter(GameManager.Heroes.Sam).GetComponent<Hero>().BonusAttack);
        PlayerPrefs.SetInt("rogueBonusAttack", GameManager.GetPlayerCharacter(GameManager.Heroes.Rogue).GetComponent<Hero>().BonusAttack);
        PlayerPrefs.SetInt("jerryBonusAttack", GameManager.GetPlayerCharacter(GameManager.Heroes.Jerry).GetComponent<Hero>().BonusAttack);
        PlayerPrefs.SetInt("charlesBonusAttack", GameManager.GetPlayerCharacter(GameManager.Heroes.Charles).GetComponent<Hero>().BonusAttack);
        SaveLoad.SaveData();
        Debug.Log("Game saved");
    }

    public void LoadGame()
    {
        RunAllLoads();
    }

    void RunAllLoads()
    {
        GameSaveData data = SaveLoad.LoadData();
        GameManager.CurrentFloorNumber = data.currentFloorNumber;
        GameManager.SetPlayerAttributes(data.characterAttack, data.characterHP, data.characterSpeed);

        GameManager.GetPlayerCharacter(GameManager.Heroes.Charles).GetComponent<Hero>().BonusAttack = PlayerPrefs.GetInt("charlesBonusAttack", 0);
        GameManager.GetPlayerCharacter(GameManager.Heroes.Jerry).GetComponent<Hero>().BonusAttack = PlayerPrefs.GetInt("jerryBonusAttack", 0);
        GameManager.GetPlayerCharacter(GameManager.Heroes.Rogue).GetComponent<Hero>().BonusAttack = PlayerPrefs.GetInt("rogueBonusAttack", 0);
        GameManager.GetPlayerCharacter(GameManager.Heroes.Sam).GetComponent<Hero>().BonusAttack = PlayerPrefs.GetInt("samBonusAttack", 0);
        GameManager.NumberUpgradesAvailable = PlayerPrefs.GetInt("numUpgrades", 0);
        Debug.Log("Game loaded");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
