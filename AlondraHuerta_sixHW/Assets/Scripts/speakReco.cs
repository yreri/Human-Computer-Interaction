using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using UnityEngine;


public class speakReco : MonoBehaviour
{
    //The dictation gets activited, the same as the text where the name city will get display 
    private DictationRecognizer _dictationRecognizer;
    [SerializeField] Text CityText;
    
    //The bool and button work together to make able and disable the dictation recognizer
    public bool OnOff;
    public Button btn_speaker;
    public Sprite speaker, speaking;
    


    // Start is called before the first frame update
    void Start()
    {
        //The dictation start disable
        OnOff = false;

    }

    public void turnOnOffListen()
    {

        //The sprite changes depending if the dictation is on or off
        if (OnOff == false)
        {
            OnOff = true;
            btn_speaker.GetComponent<Image>().sprite = speaking;

        }
        else
        {
            OnOff = false;
            btn_speaker.GetComponent<Image>().sprite = speaker;
        }

    }


    //The dictation starts working after the button is clicked
    public void Listen()
    {
        if (OnOff == true)
        {
            _dictationRecognizer = new DictationRecognizer();

            _dictationRecognizer.DictationResult += (text, HARD) =>
            {
                CityText.text = text;
            };

            _dictationRecognizer.Start();
            
        }
        else
        {
            _dictationRecognizer.Stop();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
