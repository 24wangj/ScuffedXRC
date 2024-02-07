using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoTracker : MonoBehaviour
{
    public Image blue1;
    public Image blue2;
    public Image red1;
    public Image red2;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        blue1.enabled = false;
        blue2.enabled = false;
        red1.enabled = false;
        red2.enabled = false;
    }
}
