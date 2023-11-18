using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ball3 : MonoBehaviour
{
    public ColorList1 colorList;
    public TimerBoard timerBoard;
    #region Color change
    private Color ballsColor;//level 1 balls color
    private Color collisionColor1;//Enter collision
    private Color collisionColor2;//Exit collision
    #endregion
    #region level
    Dictionary<Color, Color> colorUpgrade = new Dictionary<Color, Color>();
    private int level = 1;
    private List<Color> secondLevelColor = new List<Color>();
    #endregion
    #region level2 Color
    private Color purple = new Color(0.9333333f, 0.08235291f, 0.717019f);
    private Color green = Color.green;
    private Color orange = new Color(0.9622642f, 0.4807624f, 0.02178708f);
    private Color black = Color.black;
    #endregion
    public void Start()
    {
        produceColorBall();
        setLevelColor();
    }
    public void Update()
    {
        if (recordBalls.Count == 2)
        {
            destory(level);
            levelChange();
        }
    }
    private void produceColorBall()
    {
        ballsColor = colorList.randColor[0];
        colorList.randColor.RemoveAt(0);
        GetComponent<SpriteRenderer>().color = ballsColor;
    }
    private void setLevelColor()
    {
        colorUpgrade.Add(Color.red, purple);
        colorUpgrade.Add(Color.yellow, orange);
        colorUpgrade.Add(Color.blue, green);
        colorUpgrade.Add(purple, black);
        colorUpgrade.Add(orange, black);
        colorUpgrade.Add(green, black);
        secondLevelColor.Add(orange);
        secondLevelColor.Add(green);
        secondLevelColor.Add(purple);
    }
    private void levelChange()
    {
        if (ballsColor == purple || ballsColor == green || ballsColor == orange)
            level = 2;
        if (ballsColor == black)
            level = 3;
    }
    #region Collision
    private List<GameObject> recordBalls = new List<GameObject>();
    private List<Color> levelTwoCollisionBalls = new List<Color>();

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collisionColor1 = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;
        if (collisionColor1 == ballsColor && !secondLevelColor.Contains(ballsColor))
        {
            recordBalls.Add(collisionInfo.gameObject);
        }
        if (collisionColor1 != ballsColor && secondLevelColor.Contains(ballsColor) && secondLevelColor.Contains(collisionColor1) && !levelTwoCollisionBalls.Contains(collisionColor1))
        {
            SecondLevelBallCheck1(collisionInfo);
        }
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        collisionColor2 = collisionInfo.gameObject.GetComponent<SpriteRenderer>().color;
        if (collisionColor2 == ballsColor && !secondLevelColor.Contains(ballsColor))
        {
            recordBalls.Remove(collisionInfo.gameObject);
        }
        if (collisionColor2 != ballsColor && secondLevelColor.Contains(ballsColor) && secondLevelColor.Contains(collisionColor2) && levelTwoCollisionBalls.Contains(collisionColor2))
        {
            SecondLevelBallCheck2(collisionInfo);
        }
    }
    #endregion
    private void SecondLevelBallCheck1(Collision2D collisionInfo)
    {
        if (ballsColor == orange)
        {
            if (collisionColor1 == green)
            {
                levelTwoCollisionBalls.Add(green);
                recordBalls.Add(collisionInfo.gameObject);
            }
            if (collisionColor1 == purple)
            {
                levelTwoCollisionBalls.Add(purple);
                recordBalls.Add(collisionInfo.gameObject);
            }
        }
        if (ballsColor == green)
        {
            if (collisionColor1 == orange)
            {
                levelTwoCollisionBalls.Add(orange);
                recordBalls.Add(collisionInfo.gameObject);
            }
            if (collisionColor1 == purple)
            {
                levelTwoCollisionBalls.Add(purple);
                recordBalls.Add(collisionInfo.gameObject);
            }
        }
        if (ballsColor == purple)
        {
            if (collisionColor1 == green)
            {
                levelTwoCollisionBalls.Add(green);
                recordBalls.Add(collisionInfo.gameObject);
            }
            if (collisionColor1 == orange)
            {
                levelTwoCollisionBalls.Add(orange);
                recordBalls.Add(collisionInfo.gameObject);
            }
        }
    }
    private void SecondLevelBallCheck2(Collision2D collisionInfo)
    {
        if (ballsColor == orange)
        {
            if (collisionColor2 == green)
            {
                levelTwoCollisionBalls.Remove(green);
                recordBalls.Remove(collisionInfo.gameObject);
            }
            if (collisionColor2 == purple)
            {
                levelTwoCollisionBalls.Remove(purple);
                recordBalls.Remove(collisionInfo.gameObject);
            }
        }
        if (ballsColor == green)
        {
            if (collisionColor2 == orange)
            {
                levelTwoCollisionBalls.Remove(orange);
                recordBalls.Remove(collisionInfo.gameObject);
            }
            if (collisionColor2 == purple)
            {
                levelTwoCollisionBalls.Remove(purple);
                recordBalls.Remove(collisionInfo.gameObject);
            }
        }
        if (ballsColor == purple)
        {
            if (collisionColor2 == green)
            {
                levelTwoCollisionBalls.Remove(green);
                recordBalls.Remove(collisionInfo.gameObject);
            }
            if (collisionColor2 == orange)
            {
                levelTwoCollisionBalls.Remove(orange);
                recordBalls.Remove(collisionInfo.gameObject);
            }
        }
    }
    private void destory(int level)
    {
        if (level == 1)
        {
            Destroy(recordBalls[0]);
            Destroy(recordBalls[0]);
            ballsColor = colorUpgrade[ballsColor];
            GetComponent<SpriteRenderer>().color = ballsColor;
            timerBoard.UpdateScore(1);
        }
        if (level == 2)
        {
            Destroy(recordBalls[0]);
            Destroy(recordBalls[0]);
            ballsColor = colorUpgrade[ballsColor];
            GetComponent<SpriteRenderer>().color = ballsColor;
            timerBoard.UpdateScore(3);
        }
        if (level == 3)
        {
            Destroy(recordBalls[0]);
            Destroy(recordBalls[0]);
            Destroy(gameObject);
            timerBoard.UpdateScore(10);
        }
    }
}