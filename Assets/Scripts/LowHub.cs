using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowHub : MonoBehaviour
{
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blue")
        {
            scoreManager.blueScore += 2f;
            float random = UnityEngine.Random.Range(0, 4);
            if (random == 0)
                collision.gameObject.transform.position = new Vector3(-5, 10, -10);
            else if (random == 1)
                collision.gameObject.transform.position = new Vector3(-5, 10, 10);
            else if (random == 2)
                collision.gameObject.transform.position = new Vector3(5, 10, -10);
            else
                collision.gameObject.transform.position = new Vector3(5, 10, 10);
            collision.rigidbody.velocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "Red")
        {
            scoreManager.redScore += 2f;
            float random = UnityEngine.Random.Range(0, 4);
            if (random == 0)
                collision.gameObject.transform.position = new Vector3(-5, 10, -10);
            else if (random == 1)
                collision.gameObject.transform.position = new Vector3(-5, 10, 10);
            else if (random == 2)
                collision.gameObject.transform.position = new Vector3(5, 10, -10);
            else
                collision.gameObject.transform.position = new Vector3(5, 10, 10);
            collision.rigidbody.velocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "BlueRobot")
        {
            scoreManager.blueScore += 69f;
            float random = UnityEngine.Random.Range(0, 4);
            if (random == 0)
                collision.gameObject.transform.position = new Vector3(-5, 10, -10);
            else if (random == 1)
                collision.gameObject.transform.position = new Vector3(-5, 10, 10);
            else if (random == 2)
                collision.gameObject.transform.position = new Vector3(5, 10, -10);
            else
                collision.gameObject.transform.position = new Vector3(5, 10, 10);
            collision.rigidbody.velocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "RedRobot")
        {
            scoreManager.redScore += 69f;
            float random = UnityEngine.Random.Range(0, 4);
            if (random == 0)
                collision.gameObject.transform.position = new Vector3(-5, 10, -10);
            else if (random == 1)
                collision.gameObject.transform.position = new Vector3(-5, 10, 10);
            else if (random == 2)
                collision.gameObject.transform.position = new Vector3(5, 10, -10);
            else
                collision.gameObject.transform.position = new Vector3(5, 10, 10);
            collision.rigidbody.velocity = Vector3.zero;
        }
    }
}
