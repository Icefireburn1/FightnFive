using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class manages our sound manager. This object is persistent between scenes since it will
/// stop scenarios where scene transitions will cause audio to stop abruptly. This is referenced
/// from a lot of objects for creating sounds.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip gameBoardMusic;
    public AudioClip battleMusic;
    public AudioClip defeatMusic;
    public AudioClip victoryMusic;
    public AudioClip deathClip;
    public AudioSource audioSource;
    public float delay = 2f;
    public bool isMute;
    private float volume = 0.1f;

    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
            audioSource.volume = value;
        }
    }

    /// <summary>
    /// Set if sound muted
    /// </summary>
    /// <param name="value"></param>
    public void SetMute(bool value)
    {
        isMute = value;
        audioSource.mute = value;
    }

    /// <summary>
    /// Our scenes for deciding which music to use
    /// </summary>
    public enum SceneNames
    {
        MainMenu = 0,
        GameBoard = 1,
        Battle = 2,
        Victory = 3,
        Defeat = 4
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource.loop = true;
        audioSource.clip = mainMenuMusic;
        audioSource.volume = Volume;
        audioSource.volume = PlayerPrefs.GetFloat("volume", Volume);
        audioSource.mute = PlayerPrefs.GetInt("mute", 0) == 1;
        if (!audioSource.isPlaying)
            audioSource.PlayDelayed(delay);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Called before start methods
    private void Awake()
    {
        // We don't want duplicates of this object
        if (GameObject.FindGameObjectsWithTag("SoundManager").Length > 1)
        {
            GameObject.Destroy(gameObject);
        }
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Play a single sound one time
    /// </summary>
    /// <param name="clip"></param>
    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Play the death sound once
    /// </summary>
    public void PlayOneShotDeath()
    {
        audioSource.PlayOneShot(deathClip);
    }

    /// <summary>
    /// When a scene loads, play the music that corresponds with that stage
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.buildIndex)
        {
            case (int)SceneNames.MainMenu:
                if (audioSource.clip == mainMenuMusic)
                    return;
                audioSource.clip = mainMenuMusic;
                audioSource.PlayDelayed(delay);
                break;
            case (int)SceneNames.GameBoard:
                if (audioSource.clip == gameBoardMusic)
                    return;
                audioSource.clip = gameBoardMusic;
                audioSource.PlayDelayed(delay);
                break;
            case (int)SceneNames.Battle:
                if (audioSource.clip == battleMusic)
                    return;
                audioSource.clip = battleMusic;
                audioSource.PlayDelayed(delay);
                break;
            case (int)SceneNames.Victory:
                if (audioSource.clip == victoryMusic)
                    return;
                audioSource.clip = victoryMusic;
                audioSource.PlayDelayed(delay);
                break;
            case (int)SceneNames.Defeat:
                if (audioSource.clip == defeatMusic)
                    return;
                audioSource.clip = defeatMusic;
                audioSource.PlayDelayed(delay);
                break;
        }
    }
}
