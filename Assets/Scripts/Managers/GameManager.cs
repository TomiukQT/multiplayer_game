using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Board _board;
    
    
    
    private void Start()
    {
        _board.GenerateBoard();
    }
}
