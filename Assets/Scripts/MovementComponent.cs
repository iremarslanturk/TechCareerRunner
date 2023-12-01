using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] private float forwardMovementSpeed = 1.0f;
    [SerializeField] private float horizontalMovementSpeed = 1.0f;
    private Vector3 movementVector;
    private void Awake()
    {
        movementVector = new Vector3();
    }

    private void Update()
    {
        CalculateMovement();
    }
    private void MovementInput()
    {

        
        if (!Input.anyKey)
        {
            movementVector = Vector3.zero;
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementVector += Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementVector += Vector3.right;
        }
      
    }

    private void CalculateMovement()
    {
        MovementInput();  
        movementVector.Normalize();


        Vector3 newPosition = movementVector * forwardMovementSpeed * Time.deltaTime;
        newPosition.z += forwardMovementSpeed * Time.deltaTime;
        newPosition.x *= horizontalMovementSpeed;

        transform.position += newPosition;

    }
}
