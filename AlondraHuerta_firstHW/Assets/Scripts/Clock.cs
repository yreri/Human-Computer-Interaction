using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    //Declaration of the hands of the clock
    public GameObject secondHand;
    public GameObject minuteHand;
    public GameObject hourHand;
    
    //Declaration of the values will be display and use
    public Text hoursT, minutesT, secondsT, hours2, points;
    private int secondsText, minutesText, hoursText;

    //Declaration of buttons and images of themselves 
    public Button btn_changeTime, btn_ready, btn_hours, btn_minutes;
    public Image imgClock_back, img_changeTime, img_ready, img_hours, img_minutes;

    //String to know if a second has already pass
    string oldSeconds;

    //Bool to know if it's display the back of the clock
    private bool back = false;

    private void Awake()
    {
        //The back of the clock is disable
        imgClock_back.enabled = false;
        img_ready.enabled = false;
        img_hours.enabled = false;
        img_minutes.enabled = false;

        secondsT.gameObject.SetActive(false);
        minutesT.gameObject.SetActive(false);
        hoursT.gameObject.SetActive(false);
        hours2.gameObject.SetActive(false);
        points.gameObject.SetActive(false);

    }

    private void Update()
    {
        //The clock is initialize with predifine values
        secondsText = int.Parse(secondsT.text);
        minutesText = int.Parse(minutesT.text);
        hoursText = int.Parse(hoursT.text);

        //Seconds will save the real hour taking only the seconds
        string seconds = System.DateTime.UtcNow.ToString("ss");

        //Seconds will be different everytime a second pass 
        if(seconds != oldSeconds)
        {
            //The seconds changes
            secondsText = updateSeconds(secondsText);
            //It makes sure to read the 12 as 0 for the inside program to futher calculations
            if(hoursText == 12)
            {
                hoursText = 0;
            }
            //If seconds is equal to 0 it means a minute had passed
            if (secondsText == 0)
            {
                minutesText = updateMinutes(minutesText);
            }
            //If minutes and seconds are 0 it means an hour had passed
            if(minutesText == 0 && secondsText == 0)
            {
                hoursText = updateHour(hoursText);
            }
            
        }
        
        oldSeconds = seconds;
        UpdateTimer();

    }

    //This function will manage how the hands of the clock will be display
    void UpdateTimer()
    {
        //When iTween is used the animation for every hand is done 
        iTween.RotateTo(secondHand, iTween.Hash("z", secondsText * 6 * -1, "time", 1, "easetype", "easeOutQuint"));
        iTween.RotateTo(minuteHand, iTween.Hash("z", minutesText * 6 * -1, "time", 1, "easetype", "easeOutQuint"));
        float hourDistance = (float) minutesText / 60f;
        iTween.RotateTo(hourHand, iTween.Hash("z", (hoursText + hourDistance) * (360 / 12) * -1, "time", 1, "easetype", "easeOutQuint"));

        //asign the time to the text to display
        secondsT.text = secondsText.ToString("00");
        minutesT.text = minutesText.ToString("00");
        hoursT.text = hoursText.ToString("00");
    }

    //Update the seconds taking into account when a minute has pass
    public int updateSeconds(int secondsText)
    {
        if(secondsText < 59)
        {
            secondsText += 1;

        }
        else
        {
            secondsText = 0;
        }
        return secondsText;
    }

    //Update the minutes taking into account when a hour has pass
    public int updateMinutes(int minutesText)
    {
        if(minutesText < 59)
        {
            minutesText += 1;
            
        }
        else
        {
            minutesText = 0;
        }
        return minutesText;
    }

    //Update the hours taking into account that the clock is 12 hours in total
    public int updateHour(int hourText)
    {
        print("entre a update hour");
        if (hoursText < 11)
        {
            hoursText += 1;

            //It makes sure to display the 12 insted of 0 so it can be more user friendly
            if(back == true)
            {
                hoursT.gameObject.SetActive(true);
                hours2.gameObject.SetActive(false);
            }
            
        }
        else
        {
            hoursText = 0;
            if(back == true)
            {
                //It makes sure to display the 12 insted of 0 so it can be more user friendly
                hoursT.gameObject.SetActive(false);
                hours2.gameObject.SetActive(true);

                hours2.text = "12";
            }
            
        }
        return hoursText;
    }

    //This function is the same as updateHour but its the one used by the user through the buttons 
    public void changeHour()
    {
        if(hoursText < 11)
        {
            hoursText += 1;
            if (back == true)
            {
                //It makes sure to display the 12 insted of 0 so it can be more user friendly
                hoursT.gameObject.SetActive(true);
                hours2.gameObject.SetActive(false);
            }
        }
        else
        {
            hoursText = 0;
            if (back == true)
            {
                //It makes sure to display the 12 insted of 0 so it can be more user friendly
                hoursT.gameObject.SetActive(false);
                hours2.gameObject.SetActive(true);

                hours2.text = "12";
            }
        }

        hoursT.text = hoursText.ToString("00");
    }

    //This function is the same as updateMinutes but its the one used by the user through the buttons 
    public void changeMinutes()
    {
        if (minutesText < 59)
        {
            minutesText += 1;
        }
        else
        {
            minutesText = 0;
        }

        minutesT.text = minutesText.ToString("00");
    }


    //This function is called through the button to enable the the back part of the clock
    public void changeTime()
    {
        back = true;
        imgClock_back.enabled = true;
        img_ready.enabled = true;
        img_minutes.enabled = true;
        img_hours.enabled = true;
        points.gameObject.SetActive(true);
        minutesT.gameObject.SetActive(true);
        hoursT.gameObject.SetActive(true);
        img_changeTime.enabled = false;

        if (hoursText == 0 && back == true)
        {
            hoursT.gameObject.SetActive(false);
            hours2.gameObject.SetActive(true);

            hours2.text = "12";
        }
        if(hoursText != 0)
        {
            hoursT.gameObject.SetActive(true);
        }

        
    }

    //This function is called through the button to enable the the front part of the clock
    public void ready()
    {
        back = false;
        imgClock_back.enabled = false;
        img_ready.enabled = false;
        img_minutes.enabled = false;
        img_hours.enabled = false;
        points.gameObject.SetActive(false);
        minutesT.gameObject.SetActive(false);
        hoursT.gameObject.SetActive(false);
        hours2.gameObject.SetActive(false);

        img_changeTime.enabled = true;
    }
}
