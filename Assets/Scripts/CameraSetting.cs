using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{

    private Vector3 _mouseWorldPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RayCastMousePosition();
        }
    }

    private void RayCastMousePosition()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray,out _hit))
        {
            _mouseWorldPos = _hit.point;
            Debug.Log("Mouse Clicked");
        }
    }
}
