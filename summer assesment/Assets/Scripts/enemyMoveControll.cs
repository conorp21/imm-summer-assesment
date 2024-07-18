using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveControll : MonoBehaviour
{
    public float moveSpeed = 3f; // Speed of movement
    public float moveDistance = 2f; // Distance to move in each direction
    private bool moveRight = true; // Flag to track movement direction

    private Vector3 startPos; // Starting position of the enemy

    void Start()
    {
        startPos = transform.position; // Record the starting position
    }

    void Update()
    {
        // Calculate movement direction
        Vector3 moveDirection = moveRight ? Vector3.right : Vector3.left;

        // Move the enemy
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Check if reached the maximum distance
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            // Change direction
            moveRight = !moveRight;
        }
    }
}