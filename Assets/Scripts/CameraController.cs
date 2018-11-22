using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    GameObject player;

    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 3.34f, -6.28f);
    }
}
