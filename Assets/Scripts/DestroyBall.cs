using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "BallBlack" || other.gameObject.tag == "BallRed" || other.gameObject.tag == "BallBlue")
        {
            Destroy(other.gameObject);
            if (other.gameObject.tag == "Ball"|| other.gameObject.tag == "BallRed" || other.gameObject.tag == "BallBlue")
            {
            FindObjectOfType<GameController>().AddPoint(-5);
            }
        }
	}
}
