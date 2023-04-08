using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMovementSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * playerMovementSpeed;
        var verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * playerMovementSpeed;

        transform.Translate(horizontalInput, 0, verticalInput);
    }
}
