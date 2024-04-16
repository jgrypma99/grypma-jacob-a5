using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D ballRB;

    public float initialVelocity = 5f;
    public float unstuckVelcoity = -2f;
    public GameObject ball;
    bool isDead = false;
    bool applyVelocity = false;
    // Start is called before the first frame update
    void Awake()
    {
        ballRB.AddForce(Vector2.up * initialVelocity, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (applyVelocity)
        {
            ballRB.AddForce(ballRB.velocity.normalized * 1.5f, ForceMode2D.Impulse);
            applyVelocity = false;
        }

        if (ballRB.velocity.y == 0)
        {
            ballRB.AddForce(Vector2.up * unstuckVelcoity, ForceMode2D.Impulse);
        }

        if(isDead)
        {           
            Instantiate(ball, new Vector2(0, -4), Quaternion.identity);
            ballRB.AddForce(Vector2.up * initialVelocity, ForceMode2D.Impulse);
            GameObject.Destroy(ball);
            isDead = false;
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death Zone")
        {
            isDead = true;
        }
        
        
        if(collision.gameObject.tag == "Spinner")
        {
            applyVelocity = true;
            Debug.Log(applyVelocity);
        }
        
    }
}
