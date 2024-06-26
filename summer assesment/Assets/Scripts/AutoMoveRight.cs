using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AutoMoveRight : MonoBehaviour
{
    public float speed = 5f; // Speed at which the player moves to the right

    // Update is called once per frame
    void Update()
    {
        // Move the player to the right
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}

