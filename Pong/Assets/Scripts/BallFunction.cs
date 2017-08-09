using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFunction : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;
    
    // Use this for initialization
    void Start()
    {        
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("BallDirection", 2.0f);         // 2 seconds before ball starts moving
    }

    // To choose a random direction
    void BallDirection()
    {        
        int rand = Random.Range(0, 4); // 0 <= x < 4
        if (rand == 0)
        {
            rb2d.AddForce(new Vector2(20.0f, -15.0f));
        }
        else if (rand == 1)
        {
            rb2d.AddForce(new Vector2(-20.0f, -15.0f));
        }
        else if (rand == 2)
        {
            rb2d.AddForce(new Vector2(20.0f, 15.0f));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20.0f, 15.0f));
        }
    }

    void BallReset()
    {
        vel.y = 0.0f;
        vel.x = 0.0f;
        rb2d.velocity = vel;
        gameObject.transform.position = new Vector2(0.0f, 0.0f);
    }

    void RestartGame()
    {
        BallReset();
        Invoke("BallDirection", 1.0f);
    }

    void OnCollisionEnter2D(Collision2D coll) // Velocity change on contact
    {
        if (coll.collider.CompareTag("Player"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }
}
