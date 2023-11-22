using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public ColorList colorList;

    public void Update()
    {
        circularMotion();
        GetComponent<SpriteRenderer>().color = colorList.nextBallColor;
    }

    private void circularMotion()
    {
        if (Input.GetKey(moveLeftKey))
        {
            gameObject.transform.Rotate(0f, 0f, 0.6f);
        }
        else if (Input.GetKey(moveRightKey))
        {
            gameObject.transform.Rotate(0f, 0f, -0.6f);
        }
    }
}
