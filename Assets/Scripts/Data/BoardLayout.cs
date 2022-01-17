using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board Layout", menuName = "Layout/Board Layout")]
public class BoardLayout : ScriptableObject
{
    public List<GameObject> Back;
    public List<GameObject> Front; 
}
