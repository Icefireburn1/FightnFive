using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : Character
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
