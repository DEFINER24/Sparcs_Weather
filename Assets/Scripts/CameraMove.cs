using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayCamera(){
        GameObject.Find("Main Camera").GetComponent<MoveCamera>().MoveMain();
        GameObject.Find("Btn_Move").SetActive(false);
    }
}
