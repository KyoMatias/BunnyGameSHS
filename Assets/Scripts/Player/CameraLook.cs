using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public bool IsActive;
    public float sensitivity = 1f;
     public float maxYAngle = 80f;
     private Vector2 currentRotation;

    private Quaternion targetRotation;

    private void Awake() {
        // Initialize the target rotation to the current rotation
        targetRotation = transform.localRotation;
    }

    private void Update() {
        LookFunction();
    }

    public bool SetCamera(bool value)
    {
        IsActive = value;
        return IsActive;
    }

    void LookFunction()
    {
        if (IsActive)
        {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}