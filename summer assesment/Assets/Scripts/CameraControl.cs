using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
  
    public Transform player;        // Reference to the player's transform
    public Vector3 offset;          // Offset distance between the player and camera

    // Update is called once per frame
    void LateUpdate()
    {
        // Set the camera's position to the player's position plus the offset
        transform.position = player.position + offset;
    }
}


