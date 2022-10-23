using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void SaveMuteToggleChange()
    {
        sm.SetMute(checkBox.isOn);
        PlayerPrefs.SetInt("mute", checkBox.isOn ? 1 : 0);
    }
}
