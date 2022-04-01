using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowAnimation : MonoBehaviour
{
    public Image arrow;
    private bool displayImage;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        arrow.enabled = false;
        displayImage = false;

        StartCoroutine(arrowAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator arrowAnimation()
    {
        if(displayImage == false)
        {
            arrow.enabled = true;
            displayImage = true;
        }
        else
        {
            arrow.enabled = false;
            displayImage = false;
        }
        yield return new WaitForSeconds(time);

        StartCoroutine(arrowAnimation());
    }
}
