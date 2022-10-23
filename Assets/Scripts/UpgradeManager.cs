using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    void UpdateUpgradeText()
    {
        textAvailUpgrades.text = "Upgrades Available: " + GameManager.NumberUpgradesAvailable.ToString();
    }

    void SetButtonsInteractable(bool value)
    {
        buttonCharles.interactable = value;
        buttonJerry.interactable = value;
        buttonRogue.interactable = value;
        buttonSam.interactable = value;
    }

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
