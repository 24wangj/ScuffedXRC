using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public GameObject target;
    private float targetDistance;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 0.0f;
    private float rotX;
    private bool locked;
    void Start()
    {
        locked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        targetDistance = Vector3.Distance(transform.position, target.transform.position);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            locked = !locked;
        }

        if (locked)
        {
            transform.position = new Vector3(9, 17, 0);
            transform.eulerAngles = new Vector3(65, -90, 0);
        }
        else
        {
            // get the mouse inputs
            float y = Input.GetAxis("Mouse X") * turnSpeed;
            rotX += Input.GetAxis("Mouse Y") * turnSpeed / 2;
            // clamp the vertical rotation
            rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
            // rotate the camera
            transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
            // move the camera position
            transform.position = target.transform.position - (transform.forward * targetDistance);
        }
    }
}
