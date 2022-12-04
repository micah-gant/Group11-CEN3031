using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCameraMovement : MonoBehaviour
{
    #region Variables
    [Header("Controllers")]
    public CharacterController player;
    public Transform camTransform;

    [Header("Status Values")]
    [Tooltip("Player's speed. Determines how fast they move in all aspects.")]
    public float playerSpeed = 10.0f;
    [Tooltip("Player's rotation speed. Determines how fast their body orients to match new movement direction.")]
    public float rotationFactorPerFrame = 10.0f;
    #endregion

    void Update()
    {
        // Player Inputs: scalars that determine how much a player moves.
        float horizontal = Input.GetAxisRaw("Horizontal");  // Right-Left
        float vertical = Input.GetAxisRaw("Vertical");      // Forward-Backward

        Vector3 input = new Vector3(horizontal, 0.0f, vertical);

        // Gravity: if not grounded, do move independent of 2D and camera movement.
        Vector3 moveVector = Vector3.zero;
        if (player.isGrounded == false)
        {
            moveVector += Physics.gravity;
            player.Move(moveVector * Time.deltaTime);
        }

        // If player gives input, calculate.
        if (input != Vector3.zero)
        {
            Debug.Log("Move detected");
            CameraDisplacement(input);
        }
    }

    void CameraDisplacement(Vector3 input)
    {
        Vector3 relativeMove = CameraRelativityCalculation(input);
        handleRotation(input, relativeMove);
        relativeMove = relativeMove * playerSpeed * Time.deltaTime;
        player.Move(relativeMove);
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