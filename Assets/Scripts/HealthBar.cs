using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    public float maxHealth;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        Image[] imageComps = GetComponentsInChildren<Image>();
        foreach(Image i in imageComps)
        {
            if (i.type == Image.Type.Filled)
            {
                healthBar = i;
            }
        }
        if (healthBar == null)
        {
            throw new NullReferenceException();
        }
    }

    public Image GetImageFilledComponent()
    {
        Image[] imageComps = GetComponentsInChildren<Image>();
        foreach (Image i in imageComps)
        {
            if (i.type == Image.Type.Filled)
            {
                return i;
            }
        }
        return null;
    }

    /// <summary>
    /// Because of the timing of events, we may need to call this method
    /// to get up-to-date information on the HPBar "isDead" state
    /// </summary>
    /// <returns></returns>
    public void DoUpdateFillAmount()
    {
        if (character == null) return;

        healthBar.fillAmount = (float)character.Health / (float)character.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DoUpdateFillAmount();
    }
}
