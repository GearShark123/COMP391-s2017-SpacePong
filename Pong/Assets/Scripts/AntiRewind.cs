using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRewind : MonoBehaviour {

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    if (hitInfo.name == "Ball")
    //    {
    //        hitInfo.gameObject.SendMessage("StopRewindProcess", 0f, SendMessageOptions.RequireReceiver);
    //    }
    //}
    //void OnTriggerExit(Collider hitInfo)
    //{
    //    if (hitInfo.name == "Ball")
    //    {
    //        hitInfo.gameObject.SendMessage("StartRewindProcess", 0f, SendMessageOptions.RequireReceiver);
    //    }
    //}    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            hitInfo.gameObject.SendMessage("StartRewindProcess", 0f, SendMessageOptions.RequireReceiver);
        }
    }
    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ball")
        {
            hitInfo.gameObject.SendMessage("StopRewindProcess", 0f, SendMessageOptions.RequireReceiver);
        }
    }
}


