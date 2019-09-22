using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Character")]
public class Character : ScriptableObject {

    public string title;
    public enum Role { Knight, Princess };
    public Role role;
    public Sprite sprite;

    public int health;
    public int mana;

    public Color color;
}
