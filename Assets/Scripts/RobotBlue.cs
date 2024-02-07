using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBlue : MonoBehaviour
{
    public Rigidbody rb;
    private ArrayList cargoList;
    public GameObject blueCargo;
    public GameObject redCargo;
    public float rotateSpeed = 45f;
    public float movementForce = 1f;
    public float movementSpeed = 0.5f;
    private float targetTimeShot;
    private float misa;
    public GameObject slider;
    private Vector3 initialSliderPos;
    private CargoTrackerMultiplayer cargoTracker;

    // Start is called before the first frame update
    void Start()
    {
        cargoList = new ArrayList();
        targetTimeShot = 0.5f;
        misa = 0;
        initialSliderPos = slider.transform.position;
        cargoTracker = GameObject.Find("Canvas").GetComponent<CargoTrackerMultiplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1)
        {
            tankDrive();
        }

        if (Input.GetKey(KeyCode.RightShift) && cargoList.Count > 0 && targetTimeShot < 0 && slider.transform.position.y < 520)
        {
            misa += Time.deltaTime;
            slider.transform.position = new Vector3(slider.transform.position.x, slider.transform.position.y + 2f, slider.transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            if (cargoList.Count > 0 && targetTimeShot <= 0)
            {
                shoot(misa);
                misa = 0;
            }
            slider.transform.position = initialSliderPos;
        }

        if (targetTimeShot >= 0)
            targetTimeShot -= Time.deltaTime;

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

    private void tankDrive()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.forward * movementForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(transform.forward * -movementForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * rotateSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * rotateSpeed);
        }
    }

    private void shoot(float time)
    {
        targetTimeShot = 0.5f;
        GameObject gm;
        if ((string) cargoList[^1] == "Blue")
        {
            gm = Instantiate(blueCargo, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }
        else
        {
            gm = Instantiate(redCargo, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }
        gm.transform.position += rb.transform.forward * -0.4f;
        gm.GetComponent<Rigidbody>().AddForce(rb.transform.forward * -150 * time);
        gm.GetComponent<Rigidbody>().AddForce(0, 400 * time, 0);
        cargoList.RemoveAt(cargoList.Count - 1);

        updateCargoTracker();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        float tolerance = 0.5f;

        if (collision.collider.gameObject.tag == "Blue" && cargoList.Count < 2 && normal.x < -transform.forward.x + tolerance && normal.x > -transform.forward.x - tolerance && normal.y < -transform.forward.y + tolerance && normal.y > -transform.forward.y - tolerance)
        {
            cargoList.Add("Blue");
            Destroy(collision.gameObject);
            updateCargoTracker();
        }
        else if (collision.collider.gameObject.tag == "Red" && cargoList.Count < 2 && normal.x < -transform.forward.x + tolerance && normal.x > -transform.forward.x - tolerance && normal.y < -transform.forward.y + tolerance && normal.y > -transform.forward.y - tolerance)
        {
            cargoList.Add("Red");
            Destroy(collision.gameObject);
            updateCargoTracker();
        }
    }

    private void updateCargoTracker()
    {
        cargoTracker.ResetP2();
        if (1 <= cargoList.Count)
        {
            if ((string)cargoList[0] == "Blue")
                cargoTracker.p2Blue1.enabled = true;
            else
                cargoTracker.p2Red1.enabled = true;

            if (2 <= cargoList.Count)
            {
                if ((string)cargoList[1] == "Blue")
                    cargoTracker.p2Blue2.enabled = true;
                else
                    cargoTracker.p2Red2.enabled = true;
            }
        }
    }
}
