using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Not used at the moment, but could come in handy later on.
/// </summary>
public interface Fightable
{
    public void TakeDamage(int dmg);
    public void UseAbility(Ability ability, Character target);
    public void Heal(int amt);
}
