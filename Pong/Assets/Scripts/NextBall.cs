using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBall : MonoBehaviour
{

    #region _Variables_
    public AudioClip timeReversalSound;
    public AudioClip sparkSound;
    AudioSource audioSource;

    public GameObject spark;
    public GameObject trail;

    private Rigidbody2D rb2d;
    private Vector2 vel;
    List<Vector3> positions;

    public bool isRewind = false;
    public float recordTime;
    private float addTime = 0.025f;
    [SerializeField]
    private float minTime;

    private float myTime = 0f;
    private float myTime2 = 0f;
    private float activeTime;
    private float activeTime2;
    //private bool rewindAgain;

    #endregion

    #region _Start_

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        positions = new List<Vector3>();

        rb2d = GetComponent<Rigidbody2D>();
        Invoke("BallDirection", 1.0f);         // 2 seconds before ball starts moving
    }

    #endregion 

    #region _Update_

    // Update is called once per frame
    void Update()
    {

        //print(positions.Count);

        myTime += addTime;
        myTime2 += addTime;

        //print("myTime: " + myTime);
        //print("myTime2: " + myTime2);

        //if (rewindAgain == true)
        //{

        #region _Player 1_

        if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.S))
        {
            StopRewind();
            myTime = 0f;
            trail.SetActive(true);
            audioSource.Stop();
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && (minTime <= myTime))
        {
            activeTime += addTime;

            //print("activeTime: " + activeTime);

            if (activeTime >= 2f)
            {
                StopRewind();
                myTime = 0f;
                activeTime = 0f;
                trail.SetActive(true);
                audioSource.Stop();
            }
            else
            {
                trail.SetActive(false);
                StartRewind();
                audioSource.PlayOneShot(timeReversalSound);
            }
        }

        #endregion

        #region _Player 2_

        if (Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopRewind();
            myTime2 = 0f;
            trail.SetActive(true);
            audioSource.Stop();
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && (minTime <= myTime2))
        {
            activeTime2 += addTime;

            //print("activeTime2: " + activeTime2);

            if (activeTime2 >= 2f)
            {
                StopRewind();
                activeTime2 = 0f;
                myTime2 = 0f;
                trail.SetActive(true);
                audioSource.Stop();
            }
            else
            {
                trail.SetActive(false);
                StartRewind();
                audioSource.PlayOneShot(timeReversalSound);
            }
        }
        #endregion
        //}
    }

    #endregion

    #region _Fixed Update_

    void FixedUpdate()
    {
        if (isRewind)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    #endregion

    #region _Time_

    #region _Rewind_

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            //print("positions: " + positions[0]);
            positions.RemoveAt(0);
            print("Rewind");
        }
        else
        {
            StopRewind();
        }
    }

    #endregion

    #region _Record_

    void Record()
    {
        //if (positions.Count > 100)
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        positions.RemoveAt(positions.Count-1);
        //    }

        //}
        if (positions.Count > Mathf.Round(recordTime / Time.deltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
        }
        positions.Insert(0, transform.position);
    }

    #endregion

    #region _Start Rewind_

    void StartRewind()
    {
        isRewind = true;
        rb2d.isKinematic = true;
    }

    #endregion

    #region _Stop Rewind_

    void StopRewind()
    {
        isRewind = false;
        rb2d.isKinematic = false;
        //print(rb2d.velocity);
    }

    #endregion

    //void StartRewindProcess()
    //{
    //    rewindAgain = true;
    //    print(rewindAgain);
    //}

    //void StopRewindProcess()
    //{
    //    rewindAgain = false;
    //    print(rewindAgain);
    //}

    #endregion

    #region _Ball Direction_

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

    #endregion

    #region _Ball Reset_

    //void BallReset()
    //{
    //    vel.y = 0.0f;
    //    vel.x = 0.0f;
    //    rb2d.velocity = vel;
    //    gameObject.transform.position = new Vector2(0.0f, 0.0f);
    //}

    #endregion

    #region _Restart Game_

    //void RestartGame()
    //{
    //    BallReset();
    //    Invoke("BallDirection", 1.0f);
    //}

    #endregion

    #region _On Collision Enter 2D_

    void OnCollisionEnter2D(Collision2D coll) // Velocity change on contact
    {
        audioSource.PlayOneShot(sparkSound);
        Instantiate(spark, this.transform.position, this.transform.rotation);
        if (coll.collider.CompareTag("Player"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }
    #endregion
}




