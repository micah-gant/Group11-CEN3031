using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    #region Variables
    [Header("Controllers")]
    public CharacterController player;
    public Transform camTransform;

    [Header("Status Values")]
    [Tooltip("Player's speed. Determines how fast they move in all aspects.")]
    private float playerSpeed = 15.0f;
    [Tooltip("Player's rotation speed. Determines how fast their body orients to match new movement direction.")]
    private float rotationFactorPerFrame = 15.0f;
    #endregion

    void Update()
    {
        // Player Inputs: scalars that determine how much a player moves.
        float horizontal = Input.GetAxisRaw("Horizontal");  // Right-Left
        float normal = 0.0f;                                // Up-Down (change when jumping/falling)
        float vertical = Input.GetAxisRaw("Vertical");      // Forward-Backward

        // DEBUG: IMPLEMENT GRAVITY CHECK.

        Vector3 input = new Vector3(horizontal, normal, vertical);

        // If player gives input, calculate.
        if (input != Vector3.zero)
        {
            CameraDisplacement(input);
        }
    }

    void CameraDisplacement(Vector3 input)
    {
        Vector3 relativeMove = CameraRelativityCalculation(input);
        handleRotation(input, relativeMove);
        player.Move(relativeMove * playerSpeed * Time.deltaTime);
    }

    // Calculates direction to move in based on camera's directionals and input.
    Vector3 CameraRelativityCalculation(Vector3 input)
    {
        Vector3 forward = camTransform.forward;
        Vector3 right = camTransform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        return ((forward * input.z) + (right * input.x));
    }

    // Makes player rotate so that directionals match with camera's directionals.
    void handleRotation(Vector3 input, Vector3 relativeMove)
    {
        player.transform.forward = Vector3.Slerp(player.transform.forward, relativeMove.normalized, Time.deltaTime * rotationFactorPerFrame);
    }
}