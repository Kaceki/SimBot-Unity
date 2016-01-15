using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    /*public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;

    }*/
	public float turnSpeed = 4.0f;
	public GameObject player;
	
	private Vector3 offset;
	
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate()
	{
        if (Input.GetKey(KeyCode.Mouse1))
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;

            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }
	}
}

