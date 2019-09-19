using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour {

    public Side startingFacing = Side.left;
    private Side currentFacing = Side.left;
    private Side destinationFacing = Side.left;
    private int ROTATION_SPEED = 10;

    public enum Side { left, right, none };

    // Use this for initialization
    void Start () {
        currentFacing = destinationFacing = startingFacing;
	}
	
	// Update is called once per frame
	void Update () {

        if (currentFacing != destinationFacing)
        {
            currentFacing = Side.none;

            //Debug.Log("we gotta flip, yo!");
            if (destinationFacing == Side.left)
            {
                //Debug.Log("we need to go left.");
                transform.eulerAngles = new Vector3(0, Convert.ToInt32(transform.eulerAngles.y + ROTATION_SPEED), 0);
                if (transform.eulerAngles.y >= (0 - ROTATION_SPEED / 2) && transform.eulerAngles.y <= (0 + ROTATION_SPEED / 2)) currentFacing = Side.left;
            }
            else if (destinationFacing == Side.right)
            {
                //Debug.Log("we need to go right.");
                transform.eulerAngles = new Vector3(0, Convert.ToInt32(transform.eulerAngles.y - ROTATION_SPEED), 0);
                if (transform.eulerAngles.y >= (180 - ROTATION_SPEED / 2) && transform.eulerAngles.y <= (180 + ROTATION_SPEED / 2)) currentFacing = Side.right;
            }
        }
    }

    public void FlipSprite (Side target)
    {
        destinationFacing = target;
    }
}
