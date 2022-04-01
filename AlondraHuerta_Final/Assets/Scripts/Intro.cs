using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Intro : MonoBehaviour
{
    public AudioSource source;
    public AudioClip intro;

    public float[] waitChange;
    private int count;

    public Image board, board2, customize, customize2, prize, arrowL, arrowR, recom, recom2, recom3, prize2, A;
    public Text continueGame;

    // Start is called before the first frame update
    void Start()
    {
        source = this.GetComponent<AudioSource>();

        board.enabled = true;
        board2.enabled = true;
        recom.enabled = true;
        recom2.enabled = true;
        recom3.enabled = true;

        customize.enabled = false;
        customize2.enabled = false;
        prize.enabled = false;
        arrowR.enabled = false;
        arrowL.enabled = false;
        prize.enabled = false;
        prize2.enabled = false;
        A.enabled = false;
        continueGame.gameObject.SetActive(false);


        source.clip = intro;
        source.volume = 0.8f;
        source.Play();

        StartCoroutine(TimeToChange());
    }

    IEnumerator TimeToChange()
    {
        print(waitChange.Length);
        for(int i = 0; i < (waitChange).Length; i++)
        {
            if(i == 1)
            {
                recom.enabled = false;
                recom2.enabled = false;
                recom3.enabled = false;

                prize.enabled = true;
                prize2.enabled = true;
            }
            if(i == 2)
            {
                prize.enabled = false;
                prize2.enabled = false;

                A.enabled = true;
                continueGame.gameObject.SetActive(true);
                customize.enabled = true;
                customize2.enabled = true;
                arrowL.enabled = true;
                arrowR.enabled = true;
            }
            print(i);
            yield return new WaitForSeconds(waitChange[i]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
