using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
