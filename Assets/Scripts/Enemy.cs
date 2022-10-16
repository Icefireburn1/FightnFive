using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        base.CustomUpdate();
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
