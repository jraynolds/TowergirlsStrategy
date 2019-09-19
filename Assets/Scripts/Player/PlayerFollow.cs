using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is taken from Learn Unity.com.

public class PlayerFollow : MonoBehaviour {

    public GameObject player;

    public Vector3 offset = new Vector3(0, 1.5f, -7);

    // Use this for initialization
    void Start () {
        //offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate () {
        transform.position = player.transform.position + offset;
        //Debug.Log(player.transform.position);
        //transform.position = player.transform.position;
    }
}
