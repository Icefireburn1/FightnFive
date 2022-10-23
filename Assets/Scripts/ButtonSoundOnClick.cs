using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
