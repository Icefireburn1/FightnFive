using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, Fightable
{
    [SerializeField]
    private int attack;
    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private Ability ability1;
    [SerializeField]
    private Ability ability2;
    [SerializeField]
    private Ability ability3;
    private bool isActive;
    private Ability.StatusEffect statusEffect;
    private bool isPlayer;

    public int Attack { get => attack; set => attack = value; }
    public int Health { get => health; set => health = value; }
    public int Speed { get => speed; set => speed = value; }
    public Ability Ability1 { get => ability1; set => ability1 = value; }
    public Ability Ability2 { get => ability2; set => ability2 = value; }
    public Ability Ability3 { get => ability3; set => ability3 = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public bool IsPlayer { get => isPlayer; set => isPlayer = value; }
    public Ability.StatusEffect StatusEffect { get => statusEffect; set => statusEffect = value; }

    public void UseAbility(Ability ability, Character target)
    {
        throw new System.NotImplementedException();
    }

    public void Heal(int amt)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int dmg)
    {
        throw new System.NotImplementedException();
    }
}
