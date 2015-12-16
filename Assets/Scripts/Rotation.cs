using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    
    void Update () {
float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
        transform.Rotate(new Vector3(0.0f, (moveHorizontal+moveVertical)*100, 0.0f) * Time.deltaTime);
	}
}
