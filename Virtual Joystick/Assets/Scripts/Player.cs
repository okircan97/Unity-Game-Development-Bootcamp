using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f, friction = 0.5f, rotationSpeed = 25f;

    private Transform camTransform;

    // Fields for the speed boost.
    float lastBoost = 0;
    float boostCoolDown = 2f;
    float boostSpeed = 5f;

    Joystick joystick;

    // On start handle the rigid body properties.
    void Start()
    {
        // Get the rigid body properties.
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = rotationSpeed;
        rb.drag = friction;

        // get the main camera transform component.
        camTransform = Camera.main.transform;

        // Get the JoyStick ref.
        joystick = FindObjectOfType<Joystick>();
    }

    // On update, move the player.
    void Update()
    {
        MoveThePLayer();
    }

    // This method is to make the player move.
    void MoveThePLayer()
    {
        Vector3 movementVector = Vector3.zero;
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");

        if (movementVector.magnitude > 1)
            movementVector = movementVector.normalized;

        // Change the movement direction according to the camera transform.
        Vector3 rotationVec = camTransform.TransformDirection(movementVector);
        rotationVec = new Vector3(rotationVec.x, 0, rotationVec.z);
        rotationVec = rotationVec.normalized * movementVector.magnitude;

        // Handle the player movement according to the joystick input.
        if (joystick.inputDir != Vector3.zero)
        {
            rotationVec = joystick.inputDir;
        }

        rb.AddForce(rotationVec * movementSpeed, ForceMode.Acceleration);
    }

    // This method is to boost the player speed.
    public void BoostSpeed()
    {
        // If the cooldown is past, add a speed boost.
        if (Time.time - lastBoost > boostCoolDown)
        {
            rb.AddForce(rb.velocity.normalized * boostSpeed, ForceMode.VelocityChange);
        }
    }
}
