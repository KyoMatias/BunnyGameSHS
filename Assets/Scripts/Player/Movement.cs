using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody PlayerRB;
    
    public float baseSpeed;
    public float playerSpeed;
    public float Gravity;
    private float yMove;
    public float JumpSpeed;
    public bool IsGrounded;
    public CharacterController CharCon;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        VectorMovement();
    }
    void VectorMovement()
    {
    float PlayerForward = Input.GetAxisRaw("Vertical");
    float PlayerRight = Input.GetAxisRaw("Horizontal");

    yMove -= Gravity * Time.deltaTime;


    Vector3 cameraForward = Camera.main.transform.forward;
    Vector3 cameraRight = Camera.main.transform.right;


    cameraForward.y = 0;
    cameraForward.Normalize();

    cameraRight.y = 0;
    cameraRight.Normalize();


    Vector3 PlayerMotion = (cameraForward * PlayerForward + cameraRight * PlayerRight).normalized;
    PlayerMotion.y = yMove;
    PlayerMotion *= baseSpeed * playerSpeed * Time.deltaTime;

    CharCon.Move(PlayerMotion);
    }
}
