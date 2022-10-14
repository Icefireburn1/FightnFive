using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Fightable
{
    public void TakeDamage(int dmg);
    public void UseAbility(Ability ability, Character target);
    public void Heal(int amt);
}
