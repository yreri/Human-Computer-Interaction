using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public bool changeCamera = false;
    private Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeCamera)
        {
            transform.localPosition = new Vector3(-1.58f, 0.39f, 5.01f);
        }
        else
        {
            transform.localPosition = originalPos;
        }
    }
}
