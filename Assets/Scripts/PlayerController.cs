using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerMovementSpeed = 5f;
    [SerializeField] float playerRotationSpeed = 500;

    // Update is called once per frame
    void Update()
    {
        Vector3 isometricInputDirection = GetIsometricControllerInput();

        MovePlayer(isometricInputDirection * Time.deltaTime * playerMovementSpeed);
        RoatatePlayer(isometricInputDirection);
    }

    private Vector3 GetIsometricControllerInput() {
        var controllerInput = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0,
            Input.GetAxisRaw("Vertical")
        );

        Matrix4x4 matrixAdjusted45Degrees = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
        Vector3 skewedIsometricInputDirection = matrixAdjusted45Degrees.MultiplyPoint3x4(controllerInput);

        skewedIsometricInputDirection.Normalize();

        return skewedIsometricInputDirection;
    }

    private void MovePlayer(Vector3 movementPerFrame) {
        transform.Translate(movementPerFrame, Space.World);
    }

    private void RoatatePlayer(Vector3 inputDirection) {
         if (inputDirection != Vector3.zero) {
            var relativeForwardDirection = LookForwardDirection(inputDirection);
            Quaternion toRotation = Quaternion.LookRotation(relativeForwardDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, playerRotationSpeed * Time.deltaTime);
        }
    }

    private Vector3 LookForwardDirection(Vector3 isometricInputDirection) {
        return (transform.position + isometricInputDirection) - transform.position;
    }
}
