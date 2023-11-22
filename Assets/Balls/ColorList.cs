using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorList : MonoBehaviour
{

    public Color nextBallColor;
    private List<Color> defaultColors = new List<Color>();

    public void Awake()
    {
        defaultColors.Add(Color.red);
        defaultColors.Add(Color.blue);
        defaultColors.Add(Color.yellow);
        nextBallColor = defaultColors[Random.Range(0, 3)];
    }

    public Color getNUpdateNextBallColor() {
        Color ballColor = nextBallColor;
        nextBallColor = defaultColors[Random.Range(0, 3)];
        return ballColor;
    }

}
