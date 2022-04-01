using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMaterial : MonoBehaviour
{
    public int material;
    public Material[] myMaterials;

    private void Start()
    {

    }

    private void Update()
    {
        //GetComponent<Renderer>().material = myMaterials[material];
        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            ChangeScene();
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            material++;
            if(material > 4)
            {
                material = 0;
            }
            GetComponent<Renderer>().material = myMaterials[material];
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton4))
        {
            material--;
            if (material < 0)
            {
                material = 4;
            }
            GetComponent<Renderer>().material = myMaterials[material];
        }


    }
    public void ChangeScene()
    {
        PlayerPrefs.SetInt("selectedMat", material);
        SceneManager.LoadScene("GameScene");
    }
}

