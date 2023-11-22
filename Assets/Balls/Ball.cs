using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ball : MonoBehaviour
{
    public Color ballColor;
    public ColorList colorList;
    public TimerBoard timerBoard;

    private Dictionary<Color, List<Ball>> ballsInCollision = new Dictionary<Color, List<Ball>>();
    private Dictionary<Color, Color> colorTransition = new Dictionary<Color, Color>();

    private Color purple = new Color(0.9333333f, 0.08235291f, 0.717019f);
    private Color orange = new Color(0.9622642f, 0.4807624f, 0.02178708f);

    public void Start()
    {
        changeBallColor(colorList.getNUpdateNextBallColor());

        colorTransition[Color.red] = purple;
        colorTransition[Color.blue] = Color.green;
        colorTransition[Color.yellow] = orange;
        colorTransition[purple] = Color.black;
        colorTransition[Color.green] = Color.black;
        colorTransition[orange] = Color.black;

        ballsInCollision[Color.red] = new List<Ball>();
        ballsInCollision[Color.yellow] = new List<Ball>();
        ballsInCollision[Color.blue] = new List<Ball>();
        ballsInCollision[purple] = new List<Ball>();
        ballsInCollision[orange] = new List<Ball>();
        ballsInCollision[Color.green] = new List<Ball>();
        ballsInCollision[Color.black] = new List<Ball>();
    }

    public void Update()
    {
        checkCollidingBalls();
    }

    private void checkCollidingBalls() 
    {
        // There's gotta be a way to make this simpler and scalable but whatever
        if (ballColor == Color.red || ballColor == Color.yellow || ballColor == Color.blue) {
            if (ballsInCollision[ballColor].Count >= 2) {
                Destroy(ballsInCollision[ballColor][0].gameObject);
                Destroy(ballsInCollision[ballColor][0].gameObject);
                changeBallColor(colorTransition[ballColor]);
                timerBoard.UpdateScore(1);
            }
        } else if (ballColor == purple || ballColor == Color.green || ballColor == orange) {
            if (
                ballColor == purple
                && ballsInCollision[Color.green].Count > 0
                && ballsInCollision[orange].Count > 0
            ) {
                Destroy(ballsInCollision[Color.green][0].gameObject);
                Destroy(ballsInCollision[orange][0].gameObject);
                changeBallColor(colorTransition[ballColor]);
                timerBoard.UpdateScore(3);
            } else if (
                ballColor == Color.green
                && ballsInCollision[purple].Count > 0
                && ballsInCollision[orange].Count > 0
            ) {
                Destroy(ballsInCollision[purple][0].gameObject);
                Destroy(ballsInCollision[orange][0].gameObject);
                changeBallColor(colorTransition[ballColor]);
                timerBoard.UpdateScore(3);
            } else if (
                ballColor == orange
                && ballsInCollision[purple].Count > 0
                && ballsInCollision[Color.green].Count > 0
            ) {
                Destroy(ballsInCollision[purple][0].gameObject);
                Destroy(ballsInCollision[Color.green][0].gameObject);
                changeBallColor(colorTransition[ballColor]);
                timerBoard.UpdateScore(3);
            }
        } else if (ballColor == Color.black && ballsInCollision[Color.black].Count >= 2) {
            Destroy(ballsInCollision[Color.black][0].gameObject);
            Destroy(ballsInCollision[Color.black][0].gameObject);
            timerBoard.UpdateScore(5);
            Destroy(gameObject);
        }
    }

    private void changeBallColor(Color newBallColor)
    {
        ballColor = newBallColor;
        GetComponent<SpriteRenderer>().color = ballColor;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Ball otherBall = collisionInfo.gameObject.GetComponent<Ball>();
        if (otherBall != null) {
            ballsInCollision[otherBall.ballColor].Add(otherBall);
        }
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        Ball otherBall = collisionInfo.gameObject.GetComponent<Ball>();
        if (otherBall != null) {
            ballsInCollision[otherBall.ballColor].Remove(otherBall);
        }
    }
}