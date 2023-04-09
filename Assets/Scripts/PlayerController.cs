using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMovementSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        var movementSpeedPerFrame = movementDirection * Time.deltaTime * playerMovementSpeed;
        transform.Translate(movementSpeedPerFrame, Space.World);

        // TODO: Im not sure what this does yet so I should research it.
        if (movementDirection != Vector3.zero) {
            transform.forward =  movementDirection;
        }
    }
}
