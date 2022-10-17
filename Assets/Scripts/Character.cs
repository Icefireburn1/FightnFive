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
    private int maxHealth;
    [SerializeField]
    private int speed;
    [SerializeField]
    private Ability ability1;
    [SerializeField]
    private Ability ability2;
    [SerializeField]
    private Ability ability3;
    [SerializeField]
    private bool isAlive = true;
    private Ability.StatusEffect statusEffect;
    private bool isPlayer;
    [SerializeField]
    private Vector3 healthBarPosition;

    public int Attack { get => attack; set => attack = value; }
    public int Health { get => health; set => health = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int Speed { get => speed; set => speed = value; }
    public Ability Ability1 { get => ability1; set => ability1 = value; }
    public Ability Ability2 { get => ability2; set => ability2 = value; }
    public Ability Ability3 { get => ability3; set => ability3 = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
    public bool IsPlayer { get => isPlayer; set => isPlayer = value; }
    public Ability.StatusEffect StatusEffect { get => statusEffect; set => statusEffect = value; }
    public Vector3 HealthBarPosition { get => healthBarPosition; set => healthBarPosition = value; }

    public GameObject marker;
    public GameObject healthBar;
    

    public void UseAbility(Ability ability, Character target)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Can apply healing and damage from an ability
    /// </summary>
    /// <param name="ability"></param>
    public void ApplyAbilityToSelf(Ability ability, int othersAttack)
    {
        this.health -= ability.baseDamage + othersAttack;
        this.health += ability.healAmt;

        if (this.health <= 0)
            isAlive = false;

        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
        // TODO: check status effect
    }

    public void Heal(int amt)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int dmg)
    {
        throw new System.NotImplementedException();
    }

    public void CreateMarker()
    {
        Instantiate(marker, new Vector3(transform.position.x + .022f, transform.position.y + 0.815f), transform.rotation);
    }

    public void CustomUpdate()
    {
        if (health <= 0)
        {
            isAlive = false;
        }
    }
}
