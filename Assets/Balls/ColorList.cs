using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorList : MonoBehaviour
{

    public List<Color> randColor = new List<Color>();
    private List<Color> defaultColors = new List<Color>();

    public void Awake()
    {
        defaultColors.Add(Color.red);
        defaultColors.Add(Color.blue);
        defaultColors.Add(Color.yellow);
        for (int i = 0; i < 10; i++)
        {
            int a = Random.Range(0, 3);
            randColor.Add(defaultColors[a]);
        }
    }

    public void Update()
    {
        if (randColor.Count < 10) 
        {
            int a = Random.Range(0, 3);
            randColor.Add(defaultColors[a]);
        }
    }

}
