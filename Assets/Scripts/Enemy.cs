using UnityEngine;

/// <summary>
/// These characters are managed by AI.
/// </summary>
public class Enemy : Character
{

    // Update is called once per frame
    void Update()
    {
        CustomUpdate();
    }

    /// <summary>
    /// Easily set attributes for this enemy
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="health"></param>
    /// <param name="speed"></param>
    /// <param name="hpPosition"></param>
    public void SetAttributes(int attack, int health, int speed, Vector3 hpPosition)
    {
        Attack = attack;
        MaxHealth = health;
        Health = health;
        Speed = speed;
        HealthBarPosition = hpPosition;
    }
}
