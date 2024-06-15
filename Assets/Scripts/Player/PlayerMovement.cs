using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    // Variables de acceso publico para pwpups
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }

    private void Update()
    {
        
    }

    private void Movement()
    {

    }

    private void Jump()
    {

    }
}
