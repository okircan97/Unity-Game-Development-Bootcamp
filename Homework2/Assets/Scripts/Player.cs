using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // --------------------------------------------
    // ------------------ FIELDS ------------------
    // --------------------------------------------

    // Fields for character movement.
    public float movementSpeed;
    public float walkSpeed = 5f;
    public float runSpeed = 15f;
    public float mouseSensitivity = 5f;
    Vector3 movementDirection;

    // Fields for jumping.
    public float jumpForce = 10f;
    bool isGrounded = true;

    // Necessary references.
    Rigidbody rb;
    Animator animator;

    // --------------------------------------------
    // -------------- MONO BEHAVIORS --------------
    // --------------------------------------------

    void Start()
    {
        // Assign the references.
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Lock the cursor.
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        RotatePlayer();
        MakePlayerJump();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Plane")
        {
            isGrounded = true;
        }
    }

    // --------------------------------------------
    // -------------- OTHER METHODS ---------------
    // --------------------------------------------

    // This method is to move the player.
    public void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector3(horizontal, 0, vertical);

        if (movementDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            Walk();
        }
        else if (movementDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else if (movementDirection == Vector3.zero)
        {
            Idle();
        }

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }

    // This method is to rotate the player.
    public void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX);

    }

    // This method is to make the player jump.
    public void MakePlayerJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("I'm jumping, yuppieee!");
            animator.SetTrigger("Jump");
            StartCoroutine("WaitAndJump");
        }
    }

    // This coroutine is to add a little delay before jumping.
    IEnumerator WaitAndJump()
    {
        yield return new WaitForSeconds(.2f);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    public void Idle()
    {
        movementSpeed = 0f;
        animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    public void Walk()
    {
        movementSpeed = walkSpeed;
        animator.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    public void Run()
    {
        movementSpeed = runSpeed;
        animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }
}
