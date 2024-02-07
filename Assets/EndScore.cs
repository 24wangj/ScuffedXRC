using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScore : MonoBehaviour
{
    public TMP_Text blueScore;
    public TMP_Text redScore;
    public TMP_Text whoWon;

    // Start is called before the first frame update
    void Start()
    {
        blueScore.text = PlayerPrefs.GetString("Blue Score");
        redScore.text = PlayerPrefs.GetString("Red Score");

        if (int.Parse(blueScore.text) >= int.Parse(redScore.text))
        {
            whoWon.text = "Blue Alliance Wins!";
        }
        else
        {
            whoWon.text = "Red Alliance Wins!";
        }
    }
}
