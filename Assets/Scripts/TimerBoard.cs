using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerBoard : MonoBehaviour
{

    public SliderBar timer;
    public SimpleText score;

    [SerializeField] private float maxTime = 100;
    private float time;
    private int scoreVal;

    // Start is called before the first frame update
    void Start()
    {
        timer.SetMaxValue(maxTime);
        time = maxTime;
        scoreVal = 0;
        score.SetText("Score: " + scoreVal.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timer.SetValue(time);

        if(time < 0)
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 3);
            PlayerPrefs.SetInt("Score", scoreVal);
        }
    }

    public void UpdateScore(int socreInput)
    {
        scoreVal += socreInput;
        score.SetText("Score: " + scoreVal.ToString());
    }

    public int returnScore()
    {
        return scoreVal;
    }
}
