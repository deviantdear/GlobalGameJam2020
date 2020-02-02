using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance== null)
            {
                instance = FindObjectOfType<AudioManager>();
            }
            instance = new GameObject("Spawned Audio Manager", typeof(AudioManager)).GetComponent<AudioManager>();
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    #region Fields
    private AudioSource musicSource;
    private AudioSource ambientSource;
    private AudioSource sfxSource;

    private bool firstMusicSourceIsPlaying;

    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        //Create audio sources and save references
        musicSource = this.gameObject.AddComponent<AudioSource>();
        ambientSource = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();
    }

    //Loop music and ambient

    public void PlayMusic(AudioClip musicClip)
    {
        //Determine which source is active
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource;

        activeSource.clip = musicClip;
        activeSource.volume = 1;
        activeSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : ambientSource;
    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        if (!activeSource.isPlaying)
        {
            activeSource.Play();
        }
        float t = 0.0f;
        // Fade out
        for (t = 0; t < transitionTime; t += Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }

        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }


}
