using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    
   void Update () {
float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
		transform.Rotate(new Vector3(0.0f, Mathf.Clamp((moveHorizontal+moveVertical)*100,0.0F,1.0F ),0.0f)* Time.deltaTime);
	}

}
