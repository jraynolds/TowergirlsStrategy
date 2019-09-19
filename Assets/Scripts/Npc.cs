using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour {

    public float ACTIVATION_DISTANCE = 1.8f;

    public Individual individual;
    public Dialogue dialogue;

    public SpriteRenderer activeCircle;
    public CanvasGroup dialogueGroup;
    public Text speech;
    public float ALPHA_SPEED;

    public Flip flip;

	// Use this for initialization
	void Start () {
        dialogue.currentIndex = dialogue.targetIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {

        // Check for closeness
        bool playerIsClose = PlayerIsClose();

        if (playerIsClose)
        {
            Debug.Log("The player's close!");
            activeCircle.enabled = PlayerIsClose();

            // Flip to face player
            if (GameObject.Find("Player").transform.position.x < transform.position.x) flip.FlipSprite(Flip.Side.left);
            if (GameObject.Find("Player").transform.position.x > transform.position.x) flip.FlipSprite(Flip.Side.right);

            // Enable dialogue box
            if (dialogueGroup.alpha < 1) dialogueGroup.alpha = Mathf.Min(dialogueGroup.alpha + ALPHA_SPEED, 1.0f);

            // Update speech box
            if (Input.GetKey("z") && speech.text == dialogue.content[dialogue.targetIndex])
            {
                dialogue.Increment();
                speech.text = "";
            }
            if (speech.text != dialogue.content[dialogue.targetIndex]) speech.text = dialogue.content[dialogue.targetIndex].Substring(0, speech.text.Length + 1);
            //Debug.Log(speech.text);
        }
        else
        {
            speech.text = "";
            if (dialogueGroup.alpha > 0) dialogueGroup.alpha = Mathf.Max(dialogueGroup.alpha - ALPHA_SPEED, 0.0f);
            flip.FlipSprite(flip.startingFacing);
        }
	}

    // LateUpdate is called after Update.
    private void LateUpdate()
    {
        dialogueGroup.transform.eulerAngles = new Vector3(0, 0, 0);
    }

    bool PlayerIsClose()
    {
        return Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < ACTIVATION_DISTANCE;
    }
}
