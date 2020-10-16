using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    Rigidbody2D rb;
    [SerializeField]
    private float speed = 2;
    private float maxSpeed = 4f;
    private int damage = 1;
    private float timer = 3;
    private bool pushBall= false;

    public int ballTypeId;
    public int ballID;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        if ((rb.velocity.x == 0 || rb.velocity.y == 0) && !pushBall) {
            timer -= Time.deltaTime;
            if (timer <= 0 ) {
                pushBall = true;
            }
        }
    }


    private void FixedUpdate() {
        rb.velocity = maxSpeed * (rb.velocity.normalized);
    }


    public void SetMaxSpeed(float amount) {
        maxSpeed = speed;
    }


    public void SetDamage(int amount) {
        damage = amount;
    }

    public int GetDamage() {
        return damage;
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (pushBall) {
            if (rb.velocity.y == 0) {
                rb.AddForce(new Vector2(0, 1));
                timer = 3;
            }
            if (rb.velocity.x == 0) {
                rb.AddForce(new Vector2(1, 0));
                timer = 3;
            }
            pushBall = false;
        }
    }


    public void LoadData(Vector2 velocity, int ballid, int balltypeid) {
        rb.velocity = velocity;
        ballID = ballid;
        ballTypeId = balltypeid;
    }



}
