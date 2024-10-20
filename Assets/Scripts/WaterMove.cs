using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    Vector3 velo = Vector3.zero;
    float Timecount = 0;
    void OnTriggerStay(Collider other)
    {
    
        Timecount += Time.deltaTime;
        
        if (Timecount > 1 && Timecount < 5)
        {
            transform.position = Vector3.SmoothDamp(
                transform.position, new Vector3(0, 0, 0), ref velo, 2f);
        }
    }
   
        
    
}
