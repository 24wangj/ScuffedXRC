using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlMultiplayer : MonoBehaviour
{
 
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        transform.position = new Vector3(9, 17, 0);
        transform.eulerAngles = new Vector3(65, -90, 0);
    }
}
