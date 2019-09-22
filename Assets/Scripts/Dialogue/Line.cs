using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line {

    public Character speaker;
    public string text;

    public Line(string name, string text)
    {
        speaker = Library.Instance.getCharacterByName(name);
        this.text = text;
    }
}
