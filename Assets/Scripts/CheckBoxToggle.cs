using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Helper class to manage CheckBoxes
/// </summary>
public class CheckBoxToggle : MonoBehaviour
{
    Toggle checkBox;
    SoundManager sm;

    private void Awake()
    {
        sm = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        checkBox = GetComponent<Toggle>();
        checkBox.isOn = PlayerPrefs.GetInt("mute", 0) == 1;
    }

    /// <summary>
    /// Save music mute status to PlayerPrefs which persists between game sessions
    /// </summary>
    public void SaveMuteToggleChange()
    {
        sm.SetMute(checkBox.isOn);
        PlayerPrefs.SetInt("mute", checkBox.isOn ? 1 : 0);
    }
}
