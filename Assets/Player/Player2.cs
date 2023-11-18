using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public ColorList2 colorList;
    public void Update()
    {
        circularMotion();
        GetComponent<SpriteRenderer>().color = colorList.randColor[0];
    }

    private void circularMotion()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(0f, 0f, 0.6f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Rotate(0f, 0f, -0.6f);
        }
    }
}
