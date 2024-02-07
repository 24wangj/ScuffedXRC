using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    public Rigidbody rb;
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            float random = UnityEngine.Random.Range(0, 4);
            if (random == 0)
                transform.position = new Vector3(-5, 10, -10);
            else if (random == 1)
               transform.position = new Vector3(-5, 10, 10);
            else if (random == 2)
                transform.position = new Vector3(5, 10, -10);
            else
                transform.position = new Vector3(5, 10, 10);
            rb.velocity = Vector3.zero;
        }
    }
}
