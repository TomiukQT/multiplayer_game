using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{

    /// <summary>
    ///     min <= v < max
    /// </summary>
    public static bool V2InRange(Vector2Int v, int min, int max)
    {
        return v.x >= min && v.x < max && v.y >= min && v.y < max;
    }
    
}
