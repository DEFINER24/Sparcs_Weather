using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public int Move = 0;
    public GameObject targetPosition;
    Vector3 velo = Vector3.zero; //참조속도
    
    void Update(){
        if(Move == 1){
            transform.position = Vector3.SmoothDamp(
                transform.position, targetPosition.transform.position, ref velo, 1f);            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetPosition.transform.rotation, 0.005f);
        }
        if(Vector3.Distance(transform.position, targetPosition.transform.position) < 1f){
            Move = 2;
        }
    }
    
    public void MoveMain(){
        Move = 1;
    }
    [SerializeField]
    float _zoomSpeed = 300f; 
    [SerializeField]
    float _zoomMax = 200f; 
    [SerializeField]
    float _zoomMin = 1000f;

    [SerializeField]
    float _RotateSpeed = -1f;
    [SerializeField]
    float _inputSpeed = 1;

    private void LateUpdate()
    {
        if(Move == 2){
            CameraZoom();
            CameraRotate();
            CameraInput();
        }
        
    }

    void CameraRotate()
    {
        if (Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 rotateValue = new Vector3(y, x * -1, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
            transform.eulerAngles += rotateValue * _RotateSpeed;
        }
    }

    void CameraZoom()
    {
        float _zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        if (transform.position.y <= _zoomMax && _zoomDirection > 0)
            return;

        if (transform.position.y >= _zoomMin && _zoomDirection < 0)
            return;

        transform.position += transform.forward * _zoomDirection * _zoomSpeed;
    }

    float totalRun = 1.0f;
    private void CameraInput()
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
            p_Velocity += new Vector3(0, 1f, 0);
        if (Input.GetKey(KeyCode.S))
            p_Velocity += new Vector3(0, -1f, 0);
        if (Input.GetKey(KeyCode.Alpha1))
            p_Velocity += new Vector3(0, 0, 1f);
        if (Input.GetKey(KeyCode.Alpha2))
            p_Velocity += new Vector3(0, 0, -1f);
        if (Input.GetKey(KeyCode.A))
            p_Velocity += new Vector3(-1f, 0, 0);
        if (Input.GetKey(KeyCode.D))
            p_Velocity += new Vector3(1f, 0, 0);

        Vector3 p = p_Velocity;
        if (p.sqrMagnitude > 0)
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * 1.0f;

            p.x = Mathf.Clamp(p.x, -_inputSpeed, _inputSpeed);
            p.y = Mathf.Clamp(p.y, -_inputSpeed, _inputSpeed);
            p.z = Mathf.Clamp(p.z, -_inputSpeed, _inputSpeed);

            transform.Translate(p);
        }
    }
}
