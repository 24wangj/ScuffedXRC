using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text blueTextScore;
    public TMP_Text redTextScore;
    public float blueScore;
    public float redScore;

    // Start is called before the first frame update
    void Start()
    {
        blueScore = 0;
        redScore = 0;
        blueTextScore.text = blueScore.ToString();
        redTextScore.text = redScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        blueTextScore.text = blueScore.ToString();
        redTextScore.text = redScore.ToString();
    }
}
