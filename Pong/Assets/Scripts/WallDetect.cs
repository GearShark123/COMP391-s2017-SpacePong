using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{

    public GameObject nextBall;
    public GameObject startBall;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "StartBall")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            Destroy(GameObject.Find("StartBall"));
            Instantiate(nextBall);
            //print("StartBall");
            this.GetComponent<AudioSource>().Play();
        }
        else if (hitInfo.name == "StartBall(Clone)")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            Destroy(GameObject.Find("StartBall(Clone)"));
            Instantiate(nextBall);
            //print("StartBall(Clone)");
            this.GetComponent<AudioSource>().Play();
        }
        else if (hitInfo.name == "NextBall")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            Destroy(GameObject.Find("NextBall(Clone)"));
            Instantiate(nextBall);
            //print("NextBall");            
            this.GetComponent<AudioSource>().Play();
        }
        else if (hitInfo.name == "NextBall(Clone)")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            Destroy(GameObject.Find("NextBall(Clone)"));
            Instantiate(nextBall);
            //print("NextBall(Clone)");
            this.GetComponent<AudioSource>().Play();
        }
    }

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    if (hitInfo.name == "Ball")
    //    {
    //        string wallName = transform.name;
    //        GameManager.Score(wallName);                    
    //        hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
    //    }
    //}
}
