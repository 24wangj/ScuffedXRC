using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    private float timerTime;
    public TMP_Text blueScore;
    public TMP_Text redScore;

    // Start is called before the first frame update
    void Start()
    {
        timerTime = 150f;
    }

    // Update is called once per frame
    void Update()
    {
        timerTime -= Time.deltaTime;

        int minutes = (int) (timerTime / 60);
        int seconds = (int) (timerTime % 60);

        if (seconds < 10)
            timer.text = minutes + ":0" + seconds;
        else
            timer.text = minutes + ":" + seconds;

        if (timerTime <= 0)
        {
            PlayerPrefs.SetString("Blue Score", blueScore.text);
            PlayerPrefs.SetString("Red Score", redScore.text);
            SceneManager.LoadScene("EndScreen");
        }
    }
}
