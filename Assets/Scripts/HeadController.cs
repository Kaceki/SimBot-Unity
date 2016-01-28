using UnityEngine;
using System.Collections;


public class HeadController : MonoBehaviour
{
    public Transform target;
    public float speedfollow;
    public float speedrotate;

    private Vector3 lastPosition;
    private float step;

    void Start()
    {
    }

    void Update()
    {
        //Poruszanie się głowy po płaszczyznach x,z
        float step = speedfollow * Time.deltaTime;
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(target.position.x, target.position.y + 0.5f, target.position.z), step);

        //obliczanie wektora kierunku ruchu (bazując na aktualnej i poprzedniej pozycji)
        var direction = transform.position - lastPosition;
        //var localDirection = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;

        //przełożenie wektora na rotację głowy
        step = speedrotate * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(new Vector3 (newDir.x,0,newDir.z));
    }

}
    


