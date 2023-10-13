using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 1f;
    [SerializeField] private float collisionDistance = 0.5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D col;
    private bool isGrounded = false;
    private bool colLeft = false;
    private bool colRight = false;
    private Vector2 frameVelocity = Vector2.zero;

    [SerializeField] private LayerMask obstacleLayer;



    private void FixedUpdate(){

        CheckCollisions();
        HandleGravity();
        HandleInput();

        Move();
    }

    private void CheckCollisions(){
        isGrounded = Physics2D.CapsuleCast(col.bounds.center, col.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, collisionDistance, obstacleLayer);
        colRight = Physics2D.Raycast(col.bounds.center, Vector2.right, collisionDistance, obstacleLayer);
        colLeft = Physics2D.Raycast(col.bounds.center, Vector2.left, collisionDistance, obstacleLayer);
    }

    private void HandleGravity(){
        if (isGrounded) frameVelocity.y = 0f;

        frameVelocity += 9.81f * Time.fixedDeltaTime * Vector2.down;
    }

    private void HandleInput(){
        if (Input.GetKey(KeyCode.Space) && isGrounded){
            frameVelocity.y += jumpForce;
            isGrounded = false;
        }

        frameVelocity.x = Input.GetAxisRaw("Horizontal");
        if (colRight && frameVelocity.x > 0f) {
            frameVelocity.x = 0f;
            Debug.Log("Right");
        }
        if (colLeft && frameVelocity.x < 0f) {
            frameVelocity.x = 0f;
            Debug.Log("Left");
        }

    }

    private void Move() => rb.velocity = frameVelocity * speed;
    

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawRay(col.bounds.center, Vector2.down * collisionDistance);
        Gizmos.DrawRay(col.bounds.center, Vector2.right * collisionDistance);
        Gizmos.DrawRay(col.bounds.center, Vector2.left * collisionDistance);
    }

}
