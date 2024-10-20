using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour
{
   float Distance = 20f;
   void OnMouseDrag()
   {
        if(GameObject.Find("Main Camera").GetComponent<MoveCamera>().Move == 2){
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
          
   }
  
}

