using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxLoopSource, sfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void Start()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "StartMenu" || scene.name == "HowToPlay")
            PlayMusic("MenuMusic");
        else if (scene.name == "Win")
        {
            PlayMusic("WinMusic");
        } else if (scene.name == "Lose")
        {
            PlayMusic("LoseMusic");
        } else
            PlayMusic("GameplayMusic");
    }

    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, x => x.name == name);
        if (s == null) return;

        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) return;

        sfxSource.PlayOneShot(s.clip, 1f);
    }

    public void PlayLoopSFX(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) return;

        if (sfxLoopSource.clip == s.clip && sfxLoopSource.isPlaying) return;

        sfxLoopSource.clip = s.clip;
        sfxLoopSource.loop = true;
        sfxLoopSource.Play();
    }

    public void StopSound()
    {
        sfxLoopSource.loop = false;
        sfxLoopSource.Stop();
    }
}
