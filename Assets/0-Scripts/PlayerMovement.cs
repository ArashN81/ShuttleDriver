using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    Vector2 movements;
    public float moveSpeed = 10f;

    void FixedUpdate()
    {
        movements.x = Input.GetAxisRaw("Horizontal");
        movements.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movements);
        
        
    }
}
