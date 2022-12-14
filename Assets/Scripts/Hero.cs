using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is for characters that the player manages. We do NOT destroy these characters
/// on scene transition.
/// </summary>
public class Hero : Character
{
    public int BonusAttack { get; set; }
    public int Damage
    {
        get
        {
            return Attack + BonusAttack; // Used in damage calculations for heros
        }
    }

    private new void Start()
    {
        base.Start();
        BonusAttack = 0;
    }


    private void Awake()
    {
        IsPlayer = true;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        base.CustomUpdate();
    }

    /// <summary>
    /// Revive the character and make its hp equal to its max health.
    /// </summary>
    public void HealToFull()
    {
        Health = MaxHealth;
        IsAlive = true;
    }

    /// <summary>
    /// Used when the player ugrades a character's attack
    /// </summary>
    public void UpgradeBonusAttack()
    {
        BonusAttack += 2;
    }
}
