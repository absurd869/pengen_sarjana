using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilesmove : MonoBehaviour
{
    //private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        direction = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction.z = forwardSpeed;

        Vector3 targetPosition = transform.position.z * transform.forward;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 80 * Time.deltaTime);

       // Debug.Log(direction);
    }

    
}
