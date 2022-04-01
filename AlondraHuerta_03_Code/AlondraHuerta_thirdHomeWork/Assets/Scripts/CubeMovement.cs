using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float InputThreshold;
    public float duration;
    public Rigidbody rg_cube;
    public Text cowState;

    private Vector3 current_pos;

    bool isRolling = false;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if( !isRolling  && 
            ((x > InputThreshold || x < -InputThreshold) || 
            (y > InputThreshold || y< -InputThreshold))){
            isRolling = true;
            StartCoroutine(RollingCube(x, y));
            current_pos = transform.position;
        }

        if(current_pos.x < -4 || current_pos.x > 4 || current_pos.z < -3 || current_pos.z > 3){
            cowState.text = "Your cow does not want to go out";
            rg_cube.isKinematic = false;
        }

        if (!isRolling)
        {
            if (current_pos.x < -4 || current_pos.x > 4 || current_pos.z < -3 || current_pos.z > 3)
            {  
                transform.position = Vector3.zero;
                transform.rotation = Quaternion.identity;
                current_pos = transform.position;
                rg_cube.isKinematic = true;
                cowState.text = "Move your cow";
            }
        }

        
        
    }

    IEnumerator RollingCube(float x, float y)
    {
        float elapsed = 0.0f;

        Vector3 point = Vector3.zero;
        Vector3 axis = Vector3.zero;
        float angle = 0.0f;

        Vector3 direction = Vector3.zero;

        if(x != 0) //left or right ker
        {
            axis = Vector3.forward;
            point = x > 0 ?
                transform.position + (Vector3.right * scale) :
                transform.position + (Vector3.left * scale);
            angle = x > 0 ? -90 : 90;
            direction = x > 0 ? Vector3.right : Vector3.left;
        }
        else if( y != 0) //forward and backward key
        {
            axis = Vector3.right;
            point = y > 0 ?
                transform.position + (Vector3.forward * scale) :
                transform.position + (Vector3.back * scale);
            angle = y > 0 ? 90 : -90;
            direction = y > 0 ? Vector3.forward : Vector3.back;
        } 

        point += new Vector3(0, -scale, 0);
        Vector3 adjustPos = point + direction*scale - new Vector3(0, -0.5f, 0);
        Quaternion adjustRotation = Quaternion.Euler(direction * 90f);

        while(elapsed < duration)
        {
            elapsed += Time.deltaTime;

            transform.RotateAround(
                point, 
                axis, 
                angle / duration * Time.deltaTime);

            yield return null;
        }

        transform.position = adjustPos;
        transform.rotation = adjustRotation;
        isRolling = false;
    }
}
