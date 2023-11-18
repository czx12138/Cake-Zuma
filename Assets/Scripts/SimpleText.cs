using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleText : MonoBehaviour
{

    public Text simpleText;
    private string textVal;

    public void SetText(string textInput)
    {
        textVal = textInput;
        simpleText.text = textVal;
    }
}
