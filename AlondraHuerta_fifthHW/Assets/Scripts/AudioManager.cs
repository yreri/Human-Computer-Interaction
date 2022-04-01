using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicList;
    public Text songNameText;
    public Button btn_PlayPause;
    public Sprite play, pause;

    private AudioSource source;
    private int currentSong;
    private float musicVolume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (source.isPlaying == false)
        {
            btn_PlayPause.GetComponent<Image>().sprite = pause;
            print("false");
            currentSong--;
            if(currentSong < 0)
            {
                currentSong = musicList.Length - 1;
            }

            StartCoroutine("WaitMusic");
        }
        else
        {
            btn_PlayPause.GetComponent<Image>().sprite = play;
            print("true");
            StopCoroutine("WaitMusic");
            source.Stop();
        }
    }

    IEnumerator WaitMusic()
    {
        while (source.isPlaying)
        {
            yield return null;
        }

        NextSong();
    }

    public void NextSong()
    {
        source.Stop();
        currentSong++;

        if(currentSong > musicList.Length - 1)
        {
            currentSong = 0;
        }

        source.clip = musicList[currentSong];
        source.Play();

        ShowCurrentSong();
        
        StartCoroutine("WaitMusic");
    }

    public void PreviousSong()
    {
        source.Stop();
        currentSong--;

        if (currentSong < 0)
        {
            currentSong = musicList.Length - 1;
        }

        source.clip = musicList[currentSong];
        source.Play();

        ShowCurrentSong();

        StartCoroutine("WaitMusic");
    }

    void ShowCurrentSong()
    {
        songNameText.text = source.clip.name;
    }

    public void UpdateVolume(float volume)
    {
        musicVolume = volume;
    }

    private void Update()
    {
        source.volume = musicVolume;
    }
}
