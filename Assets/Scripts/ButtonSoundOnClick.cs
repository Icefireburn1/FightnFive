using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Fast and effective way to add sounds to our button presses
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class ButtonSoundOnClick : MonoBehaviour
{
    Button button;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(DoOnClick);
    }

    // Calls before Start
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    /// <summary>
    /// What the button will do when clicked
    /// </summary>
    void DoOnClick()
    {
        try
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayOneShot(clip);
        }
        catch (NullReferenceException)
        {
            // Do nothing...this should only happen from testing in editor anyway
        }
    }
}
