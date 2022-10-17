using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is for characters that the player manages. We do NOT destroy these characters
/// on scene transition.
/// </summary>
public class Hero : Character
{
    private void Awake()
    {
        IsPlayer = true;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        base.CustomUpdate();
    }

    public void HealToFull()
    {
        Health = MaxHealth;
        IsAlive = true;
    }
}
