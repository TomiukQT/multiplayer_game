using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InputHandler : MonoBehaviour, IInputHandler
{
     [SerializeField] private Vector3 _mousePosition = -Vector3.one;

     private void Update()
     {
          GetInput();        
     }

     private void GetInput()
     {
          if (Input.GetMouseButtonDown(0))
          {
               _mousePosition = -Vector3.one;
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               if (Physics.Raycast(ray, out var hit))
                    _mousePosition = hit.point;
          }
     }

     public Vector2Int GetSelectedTile()
     {
          return new Vector2Int(Mathf.RoundToInt(_mousePosition.x),Mathf.RoundToInt(_mousePosition.y));
     }
}
