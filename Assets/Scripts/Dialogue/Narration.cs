using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Narration : MonoBehaviour {

    public TextMeshProUGUI namePanel;

    public Image avatar;

    public TextMeshProUGUI dialogue;
    public Button button;

    public TextAsset[] narrationFiles;
    public int fileIndex;
    public Line[] lines;
    public int lineIndex;

    private static Narration _instance;
    public static Narration Instance { get { return _instance; } }

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
        fileIndex = lineIndex = 0;
        lines = ParseDialogueFile(narrationFiles[fileIndex]);
        LoadLine(lines[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLine(Line line)
    {
        if (line.speaker)
        {
            namePanel.text = line.speaker.title;
            namePanel.color = line.speaker.color;
            avatar.sprite = line.speaker.sprite;
        }
        else
        {
            namePanel.text = "";
            namePanel.color = Color.black;
            avatar.sprite = null;
        }

        dialogue.text = line.text;
    }

    public void IncrementDialogue()
    {
        lineIndex++;
        if (lineIndex >= lines.Length)
        {
            Debug.Log("we need to load a new file.");
            fileIndex++;
            if (fileIndex >= narrationFiles.Length)
            {
                // escape
                Debug.Log("we've run out of dialogue!");
            }
            lines = ParseDialogueFile(narrationFiles[fileIndex]);
            lineIndex = 0;
        }
        LoadLine(lines[lineIndex]);
    }

    public Line[] ParseDialogueFile(TextAsset file)
    {
        List<Line> lines = null;

        string fulltext = file.text;
        string[] split = fulltext.Split('\n');
        foreach (string s in split)
        {
            string name = null;
            string text = null;

            // narration line
            if (s[0] == '"')
            {
                name = null;
                text = s.Split('"')[1];
            }
            // spoken line
            else
            {
                name = s.Split(' ')[0];
                text = s.Split('"')[1];
            }
            Debug.Log(name);
            Debug.Log(text);
            Line line = new Line(name, text);
            if (lines == null) lines = new List<Line>();
            lines.Add(line);
        }

        return lines.ToArray();
    }
}
