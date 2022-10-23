using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Updates the healthbar for each character depending on their health.
/// </summary>
public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    public float maxHealth;
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetImageFilledComponent();

        if (healthBar == null)
            throw new NullReferenceException();
    }

    /// <summary>
    /// We can have multiple children with this component, so we may want to find
    /// a specific one.
    /// </summary>
    /// <returns></returns>
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
        if (healthBar == null)
        {
            healthBar = GetImageFilledComponent(); // Try this if healthBar didn't get set fast enough
        }

        healthBar.fillAmount = (float)character.Health / (float)character.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DoUpdateFillAmount();
    }
}
