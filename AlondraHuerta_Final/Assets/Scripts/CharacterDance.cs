using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDance : MonoBehaviour
{
    public bool dance = false;
    private Vector3 originalPosD;
    private Vector3 originalRotD;

    // Start is called before the first frame update
    void Start()
    {
        originalPosD = transform.localPosition;
        originalRotD = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (dance)
        {
            transform.localPosition = new Vector3(0.42f, -1.01f, 0.11f);
            transform.eulerAngles = new Vector3(-1.386f, 348.613f, 3.787f);
        }
        else
        {
            transform.eulerAngles = originalRotD;
        }
    }
}
