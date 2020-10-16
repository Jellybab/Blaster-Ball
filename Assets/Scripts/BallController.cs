using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController BC;

    [SerializeField]
    private GameObject[] ballTypes = null;

    public List<BallData> ballData = new List<BallData>();
    public List<GameObject> currentBalls = new List<GameObject>();

    private void Awake() {
        if (BC == null) {
            DontDestroyOnLoad(gameObject);
            BC = this;
        } else if (BC != this) {
            Destroy(gameObject);
        }
    }

    //ball spawning location   x = -2.5f, y = 4.3f,


    public void UpgradeBall(int ballTypeId) {

    }


    public void NewBall(int ballId) {
        BallData ball = new BallData {
            ballId = ballData.Count,
            ballTypeId = ballId,
            x = -2.5f,
            y = 4.3f,
            vx = 2,
            vy = -2
        };
        ballData.Add(ball);
    }

    public void LoadBalls() {
        foreach (BallData ballData in ballData) {

            GameObject Ball = Instantiate(ballTypes[ballData.ballTypeId], new Vector2(ballData.x, ballData.y), Quaternion.identity);
            Ball.GetComponent<Ball>().LoadData(new Vector2(ballData.vx, ballData.vy), ballData.ballId, ballData.ballTypeId);
            currentBalls.Add(Ball);

        }
    }


    public void SaveBalls() {
        ballData.Clear();
        foreach (GameObject ball in currentBalls) {

            Debug.Log("Saving Ball");
            BallData ballData = new BallData {
                x = ball.transform.position.x,
                y = ball.transform.position.y,
                vx = ball.GetComponent<Rigidbody2D>().velocity.x,
                vy = ball.GetComponent<Rigidbody2D>().velocity.y,
                ballId = ball.GetComponent<Ball>().ballID,
                ballTypeId = ball.GetComponent<Ball>().ballTypeId
            };
            this.ballData.Add(ballData);
        }
    }
}

[System.Serializable]
public class BallData
{
    public float x, y, vx, vy;
    public int ballId;
    public int ballTypeId;
}
[System.Serializable]
public class BallLevel {
    public int ballID;
    public int ballSpeed;
    public int ballDamage;

}




