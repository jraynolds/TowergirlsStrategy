using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public Character character;

    public GameObject bars;
    public SpriteRenderer image;

    public bool isHoverable = false;

    public float RAISE_AMOUNT = 1.0f;
    private Vector3 startingPosition;

	// Use this for initialization
	void Start () {
        startingPosition = transform.localPosition;

        if (character)
        {
            bars.SetActive(true);
            image.sprite = character.sprite;
            image.enabled = true;
            isHoverable = true;
        }
        else
        {
            isHoverable = false;
            bars.SetActive(false);
            image.enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (isHoverable) transform.localPosition = new Vector3(startingPosition.x, RAISE_AMOUNT, startingPosition.z);
    }

    private void OnMouseExit()
    {
        if (isHoverable) transform.localPosition = new Vector3(startingPosition.x, startingPosition.y, startingPosition.z);
    }
}
