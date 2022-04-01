using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIController : MonoBehaviour
{
    private PickFlower prizeF;
    public GameObject pickFObject;

    private MainSpaces prizeS, finishG;
    public GameObject mainSObject;

    public AudioSource source;
    public AudioClip thanks;

    private bool toQuit;

    public Image board, board2, cInstructions, prize, quit, instOrg;
    public Text instructionsTitle, instructions, finishT1, finishT2, quitT, instT;

    private bool displayI;

    // Start is called before the first frame update
    void Start()
    {
        board.enabled = false;
        board2.enabled = false;
        quit.enabled = false;
        prize.enabled = false;
        instructions.gameObject.SetActive(false);
        instructionsTitle.gameObject.SetActive(false);
        finishT1.gameObject.gameObject.SetActive(false);
        finishT2.gameObject.gameObject.SetActive(false);
        quitT.gameObject.SetActive(false);
        cInstructions.enabled = false;

        source = this.GetComponent<AudioSource>();

        displayI = false;

        prizeF = GetComponent<PickFlower>();

        prizeS = GetComponent<MainSpaces>();
        finishG = GetComponent<MainSpaces>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            if (!displayI)
            {
                board.enabled = true;
                board2.enabled = true;
                instructions.gameObject.SetActive(true);
                instructionsTitle.gameObject.SetActive(true);
                cInstructions.enabled = true;
                displayI = true;
            }
            else
            {
                board.enabled = false;
                board2.enabled = false;
                instructions.gameObject.SetActive(false);
                instructionsTitle.gameObject.SetActive(false);
                cInstructions.enabled = false;
                displayI = false;
            }
        }

        if(finishG.finishGame == true)
        {
            quit.enabled = true;
            quitT.gameObject.SetActive(true);

            instOrg.enabled = false;
            instT.gameObject.SetActive(false);

            
            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                Application.Quit();
            }
            if (prizeS.prizeSpots == true && prizeF.flowerPrize == true)
            {
                source.clip = thanks;
                source.volume = 1f;
                source.Play();

                board.enabled = true;
                board2.enabled = true;
                prize.enabled = true;
                finishT2.gameObject.SetActive(true);
            }
            else
            {
                source.clip = thanks;
                source.volume = 0.8f;
                source.Play();

                board.enabled = true;
                board2.enabled = true;
                finishT1.gameObject.SetActive(true);
            }
        }
    }
}
