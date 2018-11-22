using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStart : MonoBehaviour {
    const int BallFrequency = 4;

    int sampleBallCount;

    public GameObject[] ballPreafabs;
    public float span;
    private float currentTime = 0f;

	// Use this for initialization
	void Start () {

	}

	
	// Update is called once per frame
	void Update () {

        currentTime += Time.deltaTime;
        if(currentTime >= span)
        {
            GameObject prefab = null;

            int index = Random.Range(0, ballPreafabs.Length);
            prefab = ballPreafabs[index];

            Vector3 CreatePoint = new Vector3(Random.Range(-6, 6), 15, 19);
            GameObject ball = (GameObject)Instantiate(
                prefab,
                CreatePoint,
                Quaternion.identity
                );
            currentTime = 0f;
        }
	}
}
