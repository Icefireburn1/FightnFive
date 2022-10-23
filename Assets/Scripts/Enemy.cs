using System.Collections;
using System.Collections.Generic;
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

    public void SetAttributes(int attack, int health, int speed, Vector3 hpPosition)
    {
        Attack = attack;
        MaxHealth = health;
        Health = health;
        Speed = speed;
        HealthBarPosition = hpPosition;
    }
}
