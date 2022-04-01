using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMaterial : MonoBehaviour
{
    public Material[] myMaterials;
    private int mat;

    private void Start()
    {
        mat = PlayerPrefs.GetInt("selectedMat");
    }

    private void Update()
    {
        GetComponent<Renderer>().material = myMaterials[mat];
    }
}

