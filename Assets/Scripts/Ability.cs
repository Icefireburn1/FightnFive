using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All battle characters use this class to use abilities. Abilities can cause damage, heal,
/// and eventually cause "status effects" which will impair characters.
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AbilityScriptable", order = 1)]
public class Ability : ScriptableObject
{
    public string title;
    public string tooltip;
    public int baseDamage;
    public int healAmt;
    public int percentEffectChance;
    public EligibleTarget eligibleTargets;
    public StatusEffect statusEffect;

    public enum EligibleTarget
    {
        OneEnemy,
        OneAlly,
        AllEnemy,
        AllAlly
    }

    public enum StatusEffect
    {
        None,
        Stun
    }
}
