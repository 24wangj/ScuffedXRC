using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoTrackerMultiplayer : MonoBehaviour
{
    public Image p1Blue1;
    public Image p1Blue2;
    public Image p1Red1;
    public Image p1Red2;

    public Image p2Blue1;
    public Image p2Blue2;
    public Image p2Red1;
    public Image p2Red2;

    // Start is called before the first frame update
    void Start()
    {
        ResetP1();
        ResetP2();
    }

    public void ResetP1()
    {
        p1Blue1.enabled = false;
        p1Blue2.enabled = false;
        p1Red1.enabled = false;
        p1Red2.enabled = false;
    }

    public void ResetP2()
    {
        p2Blue1.enabled = false;
        p2Blue2.enabled = false;
        p2Red1.enabled = false;
        p2Red2.enabled = false;
    }
}
