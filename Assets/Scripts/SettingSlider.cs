using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a helper class for a "slider" object. When the player changes the slider, the game volume
/// will adjust automatically.
/// </summary>
public class SettingSlider : MonoBehaviour
{
    public SoundManager sm;
    private Slider slider;

    private void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume", sm.Volume);
    }

    public void SetVolume()
    {
        sm.Volume = slider.value;
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
