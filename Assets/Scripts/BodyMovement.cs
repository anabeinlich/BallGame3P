using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{

    [SerializeField] 
    [Range(0, 10f)] public float movementSpeed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    [Header("titulo")]
    [SerializeField] private Vector3 movementVector;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }
        */

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movementVector = new Vector3(horizontalInput, 0f, verticalInput);

        movementVector.Normalize();

        transform.Translate(movementVector *  Time.deltaTime * movementSpeed);


    }


}
