using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Board Layout", menuName = "Layout/Board Layout")]
public class BoardLayout : ScriptableObject
{
    [Header("White")]
    public List<GameObject> _whiteBack;
    public List<GameObject> _whiteFront;
    [Header("Black")]
    public List<GameObject> _blackBack;
    public List<GameObject> _blackFront;
}
