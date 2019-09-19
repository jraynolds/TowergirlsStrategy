using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{

    public string[] content;
    public int targetIndex = 0;
    public int currentIndex = 0;

    public void Increment()
    {
        targetIndex = Mathf.Min(targetIndex + 1, content.Length - 1);
        currentIndex = targetIndex;
    }
    
}
