using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickFlower : MonoBehaviour
{
    public bool flowerPrize = false;
    
    public AudioClip[] musicClips;
    public AudioSource musicSource;

    public AudioClip[] affirmationClips;

    public AudioClip picFlower, tryAgain;

    public GameObject camObject;
    private CameraChange change;

    public GameObject characterDance;
    private CharacterDance cDance;

    private Animator animator;

    private string combo;
    private GameObject flower;
    private bool finish, shortD, red, yellow, pink, purple;
    private int countRed, countYellow, countPink, countPurple, countPhrases;

    public Text cflowers, ComboTitle, Combo, Combo2, Combotemp;
    public Image board, board2, combo1, combo2, combo3, combo4;

    private void Start()
    {
        musicSource = this.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        change = camObject.GetComponent<CameraChange>();
        cDance = characterDance.GetComponent<CharacterDance>();

        combo = "";
        countRed = 0;
        countPink = 0;
        countPurple = 0;
        countYellow = 0;

        finish = false;
        shortD = false;

        red = false;
        pink = false;
        purple = false;

        board.enabled = false;
        board2.enabled = false;
        ComboTitle.gameObject.SetActive(false);
        Combo.gameObject.SetActive(false);
        Combotemp.gameObject.SetActive(false);
        combo1.gameObject.SetActive(false);
        combo2.gameObject.SetActive(false);
        combo3.gameObject.SetActive(false);
        combo4.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "RedFlower")
        {
            combo = "";
            red = true;
            flower = col.gameObject;

            board.enabled = true;
            board2.enabled = true;
            ComboTitle.gameObject.SetActive(true);
            Combo.gameObject.SetActive(true);
            Combotemp.gameObject.SetActive(true);
            combo1.gameObject.SetActive(true);

            musicSource.clip = picFlower;
            musicSource.volume = 0.6f;
            musicSource.Play();

            Dance();
        }
        if(col.tag == "PinkFlower")
        {
            combo = "";
            pink = true;
            flower = col.gameObject;

            board.enabled = true;
            board2.enabled = true;
            ComboTitle.gameObject.SetActive(true);
            Combo.gameObject.SetActive(true);
            Combotemp.gameObject.SetActive(true);
            combo2.gameObject.SetActive(true);

            musicSource.clip = picFlower;
            musicSource.volume = 0.6f;
            musicSource.Play();

            Dance();
        }
        if(col.tag == "PurpleFlower")
        {
            combo = "";
            purple = true;
            flower = col.gameObject;

            board.enabled = true;
            board2.enabled = true;
            ComboTitle.gameObject.SetActive(true);
            Combo.gameObject.SetActive(true);
            Combotemp.gameObject.SetActive(true);
            combo3.gameObject.SetActive(true);

            musicSource.clip = picFlower;
            musicSource.volume = 0.6f;
            musicSource.Play();

            Dance();
        }
        if (col.tag == "YellowFlower")
        {
            combo = "";
            yellow = true;
            flower = col.gameObject;

            board.enabled = true;
            board2.enabled = true;
            ComboTitle.gameObject.SetActive(true);
            Combo.gameObject.SetActive(true);
            Combotemp.gameObject.SetActive(true);
            combo4.gameObject.SetActive(true);

            musicSource.clip = picFlower;
            musicSource.volume = 0.6f;
            musicSource.Play();

            Dance();
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (red == true && finish == false)
        {
            musicSource.clip = tryAgain;
            musicSource.volume = 0.6f;
            musicSource.Play();

            print("sali");
            combo = "";
            red = false;

            Combotemp.text = combo;

            board.enabled = false;
            board2.enabled = false;
            ComboTitle.gameObject.SetActive(false);
            Combo.gameObject.SetActive(false);
            Combotemp.gameObject.SetActive(false);
            combo1.gameObject.SetActive(false);

            StopAllCoroutines();
        }
        if (pink == true && finish == false)
        {
            musicSource.clip = tryAgain;
            musicSource.volume = 0.6f;
            musicSource.Play();

            print("sali");
            combo = "";
            pink = false;

            Combotemp.text = combo;

            board.enabled = false;
            board2.enabled = false;
            ComboTitle.gameObject.SetActive(false);
            Combo.gameObject.SetActive(false);
            Combotemp.gameObject.SetActive(false);
            combo2.gameObject.SetActive(false);

            StopAllCoroutines();

        }
        if(purple == true && finish == false)
        {
            musicSource.clip = tryAgain;
            musicSource.volume = 0.6f;
            musicSource.Play();

            print("sali");
            combo = "";
            purple = false;

            Combotemp.text = combo;

            board.enabled = false;
            board2.enabled = false;
            ComboTitle.gameObject.SetActive(false);
            Combo.gameObject.SetActive(false);
            Combotemp.gameObject.SetActive(false);
            combo3.gameObject.SetActive(false);

            StopAllCoroutines();
        }
        if (yellow == true && finish == false)
        {
            musicSource.clip = tryAgain;
            musicSource.volume = 0.6f;
            musicSource.Play();

            print("sali");
            combo = "";
            yellow = false;

            Combotemp.text = combo;

            board.enabled = false;
            board2.enabled = false;
            ComboTitle.gameObject.SetActive(false);
            Combo.gameObject.SetActive(false);
            Combotemp.gameObject.SetActive(false);
            combo4.gameObject.SetActive(false);

            StopAllCoroutines();
        }
    }

    private void Dance()
    {
        print("combo" + combo);

        if (combo == "ABYXABYX" && red == true) 
        {
            countRed++;
            print("complete combo");
            finish = true;
            combo = "";
            Combotemp.text = combo;
            change.changeCamera = true;
            cDance.dance = true;
            if (countRed == 1)
            {
                musicSource.clip = musicClips[0];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Jazz");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
            if(countRed == 2)
            {
                musicSource.clip = musicClips[0];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Jazz1");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }    
        }

        if(combo == "YXABYXAB" && pink == true)
        {
            countPink++;
            print("complete combo");
            finish = true;
            combo = "";
            Combotemp.text = combo;
            change.changeCamera = true;
            cDance.dance = true;
            if (countPink == 1)
            {
                musicSource.clip = musicClips[1];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Rumba");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
            if (countPink == 2)
            {
                musicSource.clip = musicClips[1];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Rumba1");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
            if (countPink == 3)
            {
                musicSource.clip = musicClips[1];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Rumba2");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }

        }

        if (combo == "YABAYXAB" && purple == true)
        {
            countPurple++;
            print("complete combo");
            finish = true;
            combo = "";
            Combotemp.text = combo;
            change.changeCamera = true;
            cDance.dance = true;
            if (countPurple == 1)
            {
                musicSource.clip = musicClips[2];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Soul");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
            if (countPurple == 2)
            {
                musicSource.clip = musicClips[2];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("Soul1");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
        }

        if (combo == "YXABBAXY" && yellow == true)
        {
            countYellow++;
            print("complete combo");
            finish = true;
            combo = "";
            Combotemp.text = combo;
            change.changeCamera = true;
            cDance.dance = true;
            if (countYellow == 1)
            {
                musicSource.clip = musicClips[3];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("HipHop");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
            if (countYellow == 2)
            {
                musicSource.clip = musicClips[3];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("HipHop1");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }
            if (countYellow == 3)
            {
                musicSource.clip = musicClips[3];
                musicSource.volume = 0.1f;
                musicSource.Play();
                animator.Play("HipHop2");
                StartCoroutine(WaitForMe2());
                StartCoroutine(WaitAffirmation());
            }

        }

        if (finish == false)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                combo += "A";
                Combotemp.text = combo;
                print("A");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                combo += "B";
                Combotemp.text = combo;
                print("B");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton3))
            {
                combo += "Y";
                Combotemp.text = combo;
                print("Y");
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                combo += "X";
                Combotemp.text = combo;
                print("X");
            }

            StartCoroutine(WaitForMe());
        }
    }

    IEnumerator WaitForMe()
    {
        print("wait");
        yield return new WaitForSeconds(0.0003f);
        Dance();
    }

    IEnumerator WaitForMe2()
    {
        board.enabled = false;
        board2.enabled = false;
        ComboTitle.gameObject.SetActive(false);
        Combo.gameObject.SetActive(false);
        Combotemp.gameObject.SetActive(false);
        combo1.gameObject.SetActive(false);
        combo2.gameObject.SetActive(false);
        combo3.gameObject.SetActive(false);
        combo4.gameObject.SetActive(false);

        print("wait 2");
        print(shortD);
        if(shortD == true)
        {
            yield return new WaitForSeconds(3f);
            shortD = false;
        }

        if(shortD == false)
        {
            yield return new WaitForSeconds(2f);
        }

        red = false;
        pink = false;
        purple = false;
        yellow = false;

        change.changeCamera = false;
        cDance.dance = false;

        finish = false;
        flower.SetActive(false);
    }

    IEnumerator WaitAffirmation()
    {
        cflowers.text = (countRed + countPink + countPurple + countYellow).ToString();
        yield return new WaitForSeconds(3.5f);

        musicSource.clip = affirmationClips[countPhrases];
        musicSource.volume = 0.6f;
        musicSource.Play();
        countPhrases++;
    }

    private void Update()
    {
        int totalFlowers = countRed + countPink + countPurple + countYellow;
        if (totalFlowers == 10)
        {
            flowerPrize = true;
        }
    }
}
