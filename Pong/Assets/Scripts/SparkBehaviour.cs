using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, 5.0f);
	}
}
