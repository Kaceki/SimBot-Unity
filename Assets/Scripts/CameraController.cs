using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

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

    public float speedH = 4.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedH * Input.GetAxis("Mouse Y");
        if (Input.GetKey(KeyCode.Mouse1))
        {
            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            offset = Quaternion.Euler(-pitch, yaw, 0) * offset;

            transform.position = player.transform.position + offset;
            transform.LookAt(player.transform.position);
        }/*
        if (Input.GetKey(KeyCode.Mouse1))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }*/
    }
}

