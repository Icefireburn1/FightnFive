using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All battle characters inherit this class. It stores basic information such as
/// battle stats and battle actions.
/// </summary>
public abstract class Character : MonoBehaviour
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
    public SoundManager soundEffectSource;

    // Hurt Animation
    Vector3 normalScale;
    readonly float hurtScale = 0.8f;

    protected void Start()
    {
        normalScale = transform.localScale;

        try
        {
            soundEffectSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    public void UseAbility(Ability ability, Character target)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Can apply healing and damage from an ability
    /// </summary>
    /// <param name="ability"></param>
    public void ApplyAbilityToSelf(Ability ability, int othersDamage)
    {
        // Mainly fail-safe when testing
        if (maxHealth == 0 && health != 0)
            maxHealth = health;

        if (ability.baseDamage != 0)
        {
            this.health -= ability.baseDamage + othersDamage;
            DoDamagedAnimation();
        }
            
        if (ability.healAmt > 0)
        {
            this.health += ability.healAmt;
            DoHealedAnimation();
        }

        if (this.health <= 0)
        {
            isAlive = false;
            if (soundEffectSource != null)
                soundEffectSource.PlayOneShotDeath();
        }
            

        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
        // TODO: check status effect
    }

    /// <summary>
    /// Creates a marker object object this object.
    /// </summary>
    public void CreateMarker()
    {
        Instantiate(marker, new Vector3(transform.position.x + .022f, transform.position.y + 0.815f), transform.rotation);
    }

    /// <summary>
    /// Children can inherit this.
    /// </summary>
    public void CustomUpdate()
    {
        if (health <= 0)
        {
            isAlive = false;
        }
    }

    /// <summary>
    /// Healed animation.
    /// </summary>
    void DoHealedAnimation()
    {
        if (GetComponent<SpriteRenderer>() == null)
            return;

        var spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Color.green;
        transform.localScale = new Vector3(hurtScale, hurtScale, transform.localScale.z);
        StartCoroutine("UndoAnimation");
    }

    /// <summary>
    /// Damaged animation.
    /// </summary>
    void DoDamagedAnimation()
    {
        if (GetComponent<SpriteRenderer>() == null)
            return;

        var spriteRend = GetComponent<SpriteRenderer>();
        spriteRend.color = Color.red;
        transform.localScale = new Vector3(hurtScale, hurtScale, transform.localScale.z);
        StartCoroutine("UndoAnimation");
    }

    /// <summary>
    /// Undo the visual effects of a character being hurt.
    /// </summary>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    IEnumerator UndoAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        if (GetComponent<SpriteRenderer>() != null)
        {
            var spriteRend = GetComponent<SpriteRenderer>();
            spriteRend.color = Color.white;
            transform.localScale = normalScale;
        }
    }
}
