using UnityEngine;
using System.Collections;
using System;

public class Rotation : MonoBehaviour {

    /*void Update()
    {
        double moveHorizontal = Input.GetAxis("Horizontal");
        double moveVertical = Input.GetAxis("Vertical");
        double d = ((moveVertical * moveVertical) + (moveHorizontal * moveHorizontal));
        double move = Math.Sqrt(d);
        float result = (float)move;
        if( moveVertical < 0)
        {
            result = -result;
        }
        transform.Rotate(new Vector3(0.0f, result, 0.0f) * 5);
    }*/

   //public float speed;
    void Update()
    {
        
        Vector3 targetDir = PlayerController.SharedInstance.dir;
        transform.Rotate(targetDir *5);
        /*float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);*/
    }


}
