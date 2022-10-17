using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Easily stores information that can be parsed on game start. This makes creating/loading different
/// floors very easy.
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/FloorScriptable", order = 1)]
public class Floors : ScriptableObject
{
    public GameObject enemy1;
    public int health1;
    public int attack1;
    public int speed1;
    public GameObject enemy2;
    public int health2;
    public int attack2;
    public int speed2;
    public GameObject enemy3;
    public int health3;
    public int attack3;
    public int speed3;
    public GameObject enemy4;
    public int health4;
    public int attack4;
    public int speed4;
}
