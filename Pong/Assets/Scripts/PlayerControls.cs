using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject shield;

    public KeyCode moveUp;
    public KeyCode moveDown;
    public float speed = 10.0f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity; // vel = (0.0, 0.0);

        // Easy Pong

        //if (Input.GetKey(moveUp))
        //{
        //    vel.y = speed;
        //    rb2d.velocity = vel;
        //}
        //else if (Input.GetKey(moveDown))
        //{
        //    vel.y = -1 * speed;
        //    rb2d.velocity = vel;
        //}
        //else
        //{
        //    vel.y = 0.0f;
        //    rb2d.velocity = vel;
        //}

        if (Input.GetKey(moveUp) && !(Input.GetKey(moveUp) && Input.GetKey(moveDown)))
        {
            vel.y = speed;
            rb2d.velocity = vel;
        }
        else if (Input.GetKey(moveDown) && !(Input.GetKey(moveUp) && Input.GetKey(moveDown)))
        {
            vel.y = -1 * speed;
            rb2d.velocity = vel;
        }
        else if (Input.GetKey(moveUp) && Input.GetKey(moveDown))
        {
            this.GetComponent<AudioSource>().Play();
            vel.y = 0.0f;
            rb2d.velocity = vel;
        }
        else
        {
            vel.y = 0.0f;
            rb2d.velocity = vel;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WallTop") || collision.collider.CompareTag("WallBottom"))
        {
            this.GetComponent<AudioSource>().Play();
        }
        Instantiate(shield, this.transform);
    }

}
