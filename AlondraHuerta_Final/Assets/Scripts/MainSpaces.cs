using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainSpaces : MonoBehaviour
{
    public bool prizeSpots = false;
    public bool finishGame = false;

    public AudioClip[] meditationList;
    public AudioSource source;
    public float[] timeListening;

    public AudioClip goBack;

    public GameObject check1, check2, check3, arrow1, arrow2, arrow3, arrow4, arrow5;

    private CharacterController cc;
    private bool play, s2, s3, s4, s5, s6;
    private int countSpot = 1;

    private int currentA,cA, cB, cY, cX;
    private int totalSpot;

    public Image board, board2, arrow, CY_2, CX_2, CA_3, CB_3, CX_4, CB_4, CA_5, CY_5, CA_6, CB_6, cInstructions, cInstructionsA;
    public Text MeditationTitle, InstructionsTitle, Instructions;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        cc = GetComponent<CharacterController>();

        cA = 0;
        cB = 0;
        cX = 0;
        cY = 0;
        totalSpot = 0;

        board.enabled = false;
        board2.enabled = false;
        arrow.enabled = false;

        Instructions.gameObject.SetActive(false);
        InstructionsTitle.gameObject.SetActive(false);
        cInstructions.enabled = false;
        cInstructionsA.enabled = false;

        CY_2.enabled = false;
        CX_2.enabled = false;

        CA_3.enabled = false;
        CB_3.enabled = false;

        CX_4.enabled = false;
        CB_4.enabled = false;

        CA_5.enabled = false;
        CY_5.enabled = false;

        CA_6.enabled = false;
        CB_6.enabled = false;

        MeditationTitle.gameObject.SetActive(false);

        play = false;
        s2 = false;
        s3 = false;
        s4 = false;
        s5 = false;
        s6 = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "1_Spot" && countSpot == 1)
        {
            print("spot 1");
            board.enabled = true;
            board2.enabled = true;
            Instructions.gameObject.SetActive(true);
            InstructionsTitle.gameObject.SetActive(true);
            cInstructions.enabled = true;

            currentA = 0;
            playAudios(currentA);
        }

        if(col.tag == "2_Spot" && countSpot == 2)
        {
            print("spot 2");
            currentA++;
            s2 = true;

            board.enabled = true;
            board2.enabled = true;
            arrow.enabled = true;
            CY_2.enabled = true;
            CX_2.enabled = true;
            MeditationTitle.gameObject.SetActive(true);

            arrow1.gameObject.SetActive(false);

            playAudios(currentA);
        }

        if (col.tag == "3_Spot" && countSpot == 3)
        {
            print("spot 3");
            currentA++;
            s3 = true;

            board.enabled = true;
            board2.enabled = true;
            arrow.enabled = true;
            CA_3.enabled = true;
            CB_3.enabled = true;
            MeditationTitle.gameObject.SetActive(true);

            arrow2.gameObject.SetActive(false);

            playAudios(currentA);
        }

        if (col.tag == "4_Spot" && countSpot == 4)
        {
            print("spot 4");
            currentA++;
            s4 = true;

            board.enabled = true;
            board2.enabled = true;
            arrow.enabled = true;
            CX_4.enabled = true;
            CB_4.enabled = true;
            MeditationTitle.gameObject.SetActive(true);

            arrow3.gameObject.SetActive(false);

            playAudios(currentA);
        }

        if (col.tag == "5_Spot" && countSpot == 5)
        {
            print("spot 5");
            currentA++;
            s5 = true;

            board.enabled = true;
            board2.enabled = true;
            arrow.enabled = true;
            CA_5.enabled = true;
            CY_5.enabled = true;
            MeditationTitle.gameObject.SetActive(true);

            arrow4.gameObject.SetActive(false);

            playAudios(currentA);
        }
        if (col.tag == "6_Spot" && countSpot == 6)
        {
            print("spot 6");
            currentA++;
            s6 = true;

            board.enabled = true;
            board2.enabled = true;
            arrow.enabled = true;
            CA_6.enabled = true;
            CB_6.enabled = true;
            MeditationTitle.gameObject.SetActive(true);

            arrow5.gameObject.SetActive(false);

            playAudios(currentA);
        }
        if(col.tag == "check1" && countSpot == 2)
        {
            source.clip = goBack;
            source.volume = 0.6f;
            source.Play();
        }
        if (col.tag == "check2" && countSpot== 4)
        {
            source.clip = goBack;
            source.volume = 0.6f;
            source.Play();
        }
        if (col.tag == "check3" && countSpot == 5)
        {
            source.clip = goBack;
            source.volume = 0.6f;
            source.Play();
        }

    }

    private void playAudios(int currentA)
    {
        print(meditationList[currentA]);
        source.clip = meditationList[currentA];
        source.Play();
        FreezePos();
    }

    private void FreezePos()

    {
        cc.enabled = false;
        StartCoroutine(WaitForMeditation());
    }

    IEnumerator WaitForMeditation()
    {
        if(countSpot == 1)
        {
            yield return new WaitForSeconds(timeListening[0]);
            cInstructions.enabled = false;
            cInstructionsA.enabled = true;
            play = true;
        }
        else
        {
            yield return new WaitForSeconds(timeListening[countSpot - 1]);

            board.enabled = false;
            board2.enabled = false;
            arrow.enabled = false;

            CY_2.enabled = false;
            CX_2.enabled = false;

            CA_3.enabled = false;
            CB_3.enabled = false;

            CX_4.enabled = false;
            CB_4.enabled = false;

            CA_5.enabled = false;
            CY_5.enabled = false;

            CA_6.enabled = false;
            CB_6.enabled = false;

            MeditationTitle.gameObject.SetActive(false);

            cc.enabled = true;
            countSpot++;

            if (countSpot == 7)
            {
                finishGame = true;
            }
            

        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0) && countSpot == 1 && play == true)
        {
            board.enabled = false;
            board2.enabled = false;
            Instructions.gameObject.SetActive(false);
            InstructionsTitle.gameObject.SetActive(false);
            cInstructionsA.enabled = false;

            cc.enabled = true;
            countSpot++;
        }
        if(countSpot == 2 && s2 == true)
        {
            print("entre a spot 2");
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                cY++;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                cX++;
            }
            if(cY > 3 && cX > 3)
            {
                totalSpot++;
                s2 = false;
                cX = 0;
                cY = 0;
                print("total count spot" + totalSpot);
            }
        }
        if (countSpot == 3 && s3 == true)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                cA++;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                cB++;
            }
            if (cA > 3 && cB > 3)
            {
                totalSpot++;
                s3 = false;
                cA = 0;
                cB = 0;
                print("total count spot" + totalSpot);
            }
        }
        if (countSpot == 4 && s4 == true)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                cX++;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                cB++;
            }
            if (cX > 3 && cB > 3)
            {
                totalSpot++;
                s4 = false;
                cX = 0;
                cB = 0;
                print("total count spot" + totalSpot);
            }
        }
        if (countSpot == 5 && s5 == true)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                cA++;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                cY++;
            }
            if (cA > 2 && cY > 2)
            {
                totalSpot++;
                s5 = false;
                cA = 0;
                cY = 0;
                print("total count spot" + totalSpot);
            }
        }
        if (countSpot == 6 && s6 == true)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                cA++;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                cB++;
            }
            if (cA > 2 && cB > 2)
            {
                totalSpot++;
                s6 = false;
                cA = 0;
                cB = 0;
                print("total count spot" + totalSpot);
            }
        }
        if(totalSpot == 5)
        {
            prizeSpots = true;
        }
    }

}
