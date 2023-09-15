using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraHandler : MonoBehaviour
{
    public Transform bakis; // takip edeceği şeyin transformu
    public Vector3 denge, istenilenPos;
    [SerializeField] float mesafe = 19f, puruzHizi = 7.5f, yDenge = 10f;

    // A vector to change the camera rotation according to the touch input.
    Vector2 touchPos;
    float rotationSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        denge = new Vector3(0f, yDenge, 1f * mesafe);
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraMov();
    }


    void HandleCameraMov()
    {
        // Change the camera rotation according to the key input.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SlideCamera(true);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SlideCamera(false);
        }

        // Change the camera rotation according to the mouse input.
        // It works by dragging the mouse.
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            touchPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            float sweepForce = touchPos.x - Input.mousePosition.x;
            if (Mathf.Abs(sweepForce) > rotationSpeed)
            {
                if (sweepForce < 0)
                    SlideCamera(true);
                else
                    SlideCamera(false);
            }
        }
    }

    void FixedUpdate()
    {
        istenilenPos = bakis.position + denge;
        transform.position = Vector3.Lerp(transform.position, istenilenPos, puruzHizi * Time.deltaTime);
        transform.LookAt(bakis.position + Vector3.up);
    }

    public void SlideCamera(bool left)
    {
        if (left)
            denge = Quaternion.Euler(0, 90, 0) * denge;
        else
            denge = Quaternion.Euler(0, -90, 0) * denge;
    }
}
