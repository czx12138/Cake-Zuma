using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public ColorList1 colorList;
    public void Update()
    {
        circularMotion();
        GetComponent<SpriteRenderer>().color = colorList.randColor[0];
    }

    private void circularMotion()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(0f, 0f, 0.6f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Rotate(0f, 0f, -0.6f);
        }
    }
}
