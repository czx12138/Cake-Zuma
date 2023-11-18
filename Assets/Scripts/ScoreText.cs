using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public TMP_Text scoreText;
    int storedScore;

    void Start()
    {
        storedScore = PlayerPrefs.GetInt("Score");
        scoreText.SetText(storedScore.ToString());
    }
}
