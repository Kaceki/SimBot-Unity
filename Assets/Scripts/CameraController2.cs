using UnityEngine;
using System.Collections;

public class CameraController2 : MonoBehaviour
{
    public GameObject target;

    public float distanceAway;
    public float distanceUp;
    public float smooth;
    private Transform follow;
    private Vector3 targetPosition;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float speedH = 4.0f;
    public float speedV = 2.0f;
    private Vector3 offset;

    void Start()
    {
        follow = target.transform;
        offset = transform.position - target.transform.position;   //cameracontroller1
    }

    void LateUpdate()
    {
        targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
        /*Debug.DrawRay(follow.position, Vector3.up * distanceUp, Color.red);
        Debug.DrawRay(follow.position, -1f * follow.forward * distanceAway, Color.blue);
        Debug.DrawLine(follow.position, targetPosition, Color.magenta);*/

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);

        //zwracanie kamery w kierunku BB8
        transform.LookAt(follow);


        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.position = target.transform.position + offset;
            yaw = speedH * Input.GetAxis("Mouse X");
            pitch = speedH * Input.GetAxis("Mouse Y");

            //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            offset = Quaternion.Euler(-pitch, yaw, 0) * offset;

            transform.position = target.transform.position + offset;
            transform.LookAt(target.transform.position);

        }
    }
}