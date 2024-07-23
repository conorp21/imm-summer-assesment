using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager instance;

    // Variables to track player lives and keys
    public int playerLives = 3;
    public int playerKeys = 0;

    void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add a life
    public void AddLife()
    {
        playerLives++;
        
    }

    // Method to remove a life
    public void RemoveLife()
    {
        if (playerLives > 0)
        {
            playerLives--;
           

            if (playerLives == 0)
            {
                GameOver();
            }
        }
    }

    // Method to add a key
    public void AddKey()
    {
        playerKeys++;
    
    }

    // Method to remove a key
    public void RemoveKey()
    {
        if (playerKeys > 0)
        {
            playerKeys--;
            
        }
    }

    // Method called when player lives reach 0
    void GameOver()
    {
        Debug.Log("Game Over!");
        // Implement game over logic here (e.g., restart level, show game over screen)
    }
}

