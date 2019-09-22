using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour {

    private static Library _instance;
    public static Library Instance { get { return _instance; } }

    public Character[] characters;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Character getCharacterByName(string name)
    {
        foreach (Character c in characters)
        {
            if (c.title == name) return c;
        }
        return null;
    }
}
