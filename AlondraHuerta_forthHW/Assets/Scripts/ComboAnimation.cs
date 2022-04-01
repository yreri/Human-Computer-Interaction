using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboAnimation : MonoBehaviour
{
    private Animator animator;

    public bool GetHitF1, GetHitR1, Walk, Attack;
    public Text comboText;

    private float maxTime = 0;

    private string Combo;


    // Start is called before the first frame update
    void Start()
    {
        //It initialize all the triggers as false, and get the empty combo text
        Combo = "";
        animator = GetComponent<Animator>();
        GetHitF1 = false;
        GetHitR1 = false;
        Walk = false;
        Attack = false;
        comboText.text = Combo;
    }

    IEnumerator WaitForMe()
    {
        //This function is called so the animation can be display and stop after just one round of animation
        yield return new WaitForSeconds(0.0001f);
        GetHitF1 = false;
        GetHitR1 = false;
        Walk = false;
        Attack = false;
        Combo = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        comboText.text = Combo;
        maxTime += Time.deltaTime;

        if(maxTime > 5f)
        {
            print(Combo);
            maxTime = 0f;
            Combo = "";
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            maxTime = 0f;
            Combo += "B";
            comboText.text = Combo;
        }
        if(Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            maxTime = 0f;
            Combo += "A";
            comboText.text = Combo;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            maxTime = 0f;
            Combo += "Y";
            comboText.text = Combo;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            maxTime = 0f;
            Combo += "X";
            comboText.text = Combo;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button4))
        {
            maxTime = 0f;
            Combo += "L";
            comboText.text = Combo;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            maxTime = 0f;
            Combo += "R";
            comboText.text = Combo;
        }


        //It checks if it gets a combo and if it get it makes true the trigger
        if (Combo == "BAB")
        {
            comboText.text = Combo;
            GetHitF1 = true;
            StartCoroutine(WaitForMe());
        }
        if (Combo == "YYXA")
        {
            comboText.text = Combo;
            GetHitR1 = true;
            StartCoroutine(WaitForMe());
        }
        if (Combo == "LRY")
        {
            comboText.text = Combo;
            Walk = true;
            StartCoroutine(WaitForMe());
        }
        if (Combo == "XAR")
        {
            comboText.text = Combo;
            Attack = true;
            StartCoroutine(WaitForMe());
        }


        //It sets the triggers true if it get the complete combo from the user
        if (GetHitF1)
        {
            animator.SetTrigger("GetHitF1");
        }
        if (GetHitR1)
        {
            animator.SetTrigger("GetHitR1");
        }
        if (Walk)
        {
            animator.SetTrigger("Walk");
        }
        if (Attack)
        {
            animator.SetTrigger("Attack");
        }

    }
}
