using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class manages the entire upgrade character screen. It will allow, and control units getting upgraded.
/// It will also control the UI and update it accordingly.
/// </summary>
public class UpgradeManager : MonoBehaviour
{
    public Button buttonCharles;
    public Button buttonJerry;
    public Button buttonRogue;
    public Button buttonSam;
    public TextMeshProUGUI textDamageCharles;
    public TextMeshProUGUI textDamageJerry;
    public TextMeshProUGUI textDamageRogue;
    public TextMeshProUGUI textDamageSam;
    public TextMeshProUGUI textAvailUpgrades;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.NumberUpgradesAvailable > 0)
        {
            SetButtonsInteractable(true);
        }
        else
        {
            SetButtonsInteractable(false);
        }
        UpdateUpgradeText();
        UpdateDamageText();
    }

    /// <summary>
    /// Updates the upgrade available UI text
    /// </summary>
    void UpdateUpgradeText()
    {
        textAvailUpgrades.text = "Upgrades Available: " + GameManager.NumberUpgradesAvailable.ToString();
    }

    /// <summary>
    /// Set all upgrade buttons interactable status
    /// </summary>
    /// <param name="value"></param>
    void SetButtonsInteractable(bool value)
    {
        buttonCharles.interactable = value;
        buttonJerry.interactable = value;
        buttonRogue.interactable = value;
        buttonSam.interactable = value;
    }

    /// <summary>
    /// Apply the damage increase when characters are upgraded. Also, adjust UI when not eligible for upgrading.
    /// </summary>
    /// <param name="buttonNumber"></param>
    public void DoUpgradeUnit(int buttonNumber)
    {
        switch (buttonNumber)
        {
            case 1:
                var heroCharles = GameManager.GetPlayerCharacter(GameManager.Heroes.Charles).GetComponent<Hero>();
                heroCharles.UpgradeBonusAttack();
                break;
            case 2:
                var heroJerry = GameManager.GetPlayerCharacter(GameManager.Heroes.Jerry).GetComponent<Hero>();
                heroJerry.UpgradeBonusAttack();
                break;
            case 3:
                var heroRogue = GameManager.GetPlayerCharacter(GameManager.Heroes.Rogue).GetComponent<Hero>();
                heroRogue.UpgradeBonusAttack();
                break;
            case 4:
                var heroSam = GameManager.GetPlayerCharacter(GameManager.Heroes.Sam).GetComponent<Hero>();
                heroSam.UpgradeBonusAttack();
                break;
        }

        GameManager.NumberUpgradesAvailable--;

        if (GameManager.NumberUpgradesAvailable > 0)
        {
            SetButtonsInteractable(true);
        }
        else
        {
            SetButtonsInteractable(false);
        }
        UpdateUpgradeText();
        UpdateDamageText();
    }

    /// <summary>
    /// Update the UI when upgrading damage
    /// </summary>
    void UpdateDamageText()
    {
        var heroCharles = GameManager.GetPlayerCharacter(GameManager.Heroes.Charles).GetComponent<Hero>();
        textDamageCharles.text = "+" + heroCharles.BonusAttack + " Damage";

        var heroJerry = GameManager.GetPlayerCharacter(GameManager.Heroes.Jerry).GetComponent<Hero>();
        textDamageJerry.text = "+" + heroJerry.BonusAttack + " Damage";

        var heroRogue = GameManager.GetPlayerCharacter(GameManager.Heroes.Rogue).GetComponent<Hero>();
        textDamageRogue.text = "+" + heroRogue.BonusAttack + " Damage";

        var heroSam = GameManager.GetPlayerCharacter(GameManager.Heroes.Sam).GetComponent<Hero>();
        textDamageSam.text = "+" + heroSam.BonusAttack + " Damage";
    }
}
