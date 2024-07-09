using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator anim;
    public LayerMask ObjectsLayer; // Define the LayerMask for collidable objects

    private Vector2 moveDirection;

    void Start()
    {
        // Ensure the player is on the correct sorting layer
        GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        GetComponent<SpriteRenderer>().sortingOrder = 1; // Ensure it's above the objects
    }

    void Update()
    {
        ProcessInput();
        Animate();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        Vector2 targetPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

        if (IsWalkable(targetPosition))
        {
            rb.MovePosition(targetPosition);
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop movement if collision detected
        }
    }

    void Animate()
    {
        anim.SetFloat("AnimMoveX", moveDirection.x);
        anim.SetFloat("AnimMoveY", moveDirection.y);
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        // Perform a collision check using OverlapCircle
        return Physics2D.OverlapCircle(targetPos, 0.2f, ObjectsLayer) == null;
    }
}