using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1500f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move with input
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // When jump button is pressed, add upward force
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Make sure to use impulse for jump instead of lift 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // When making ground contact, allow jump
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("obstacle"))
        {
            isGrounded = true;
        }
    }

    // When already touching ground, allow jump
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("obstacle"))
        {
            isGrounded = true;
        }
    }

    // When stop touching ground, do not allow jump
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Handle trigger events
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            GameManager.instance.AddKey();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Door"))
        {
            if (GameManager.instance.playerKeys > 2)
            {
                GameManager.instance.RemoveKey();
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.RemoveLife();
            StartCoroutine(HandleEnemyCollision());
        }
    }

    // Coroutine to handle a delay after colliding with an enemy
    private IEnumerator HandleEnemyCollision()
    {
        // Implement any logic that should occur after colliding with an enemy
        yield return new WaitForSeconds(2);
        // Additional logic after waiting
    }
}
