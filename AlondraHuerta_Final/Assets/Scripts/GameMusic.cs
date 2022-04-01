using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource gMusic;
    public AudioClip music;

    // Start is called before the first frame update
    void Start()
    {

        gMusic = this.GetComponent<AudioSource>();

        gMusic.clip = music;
        gMusic.volume = 0.08f;
        gMusic.Play();
        gMusic.Play();

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
