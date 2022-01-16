using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector2Int _coordinates;

    public void Setup(Vector2Int coords)
    {
        _coordinates = coords;
    }
}
