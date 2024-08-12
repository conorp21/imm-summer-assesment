using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    // Singleton instance
    public static DifficultyManager instance;

    // Variables to store difficulty settings
    public int playerLives;
    public int playerKeys;
    public int numberOfEnemies;
    public int numberOfPowerups;

    void Awake()
    {
        // Ensure there's only one instance of DifficultyManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the DifficultyManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Methods to set difficulty
    public void SetEasyDifficulty()
    {
        playerLives = 3;
        playerKeys = 3;
        numberOfEnemies = 3;
        numberOfPowerups = 3;
    }

    public void SetMediumDifficulty()
    {
        playerLives = 2;
        playerKeys = 3;
        numberOfEnemies = 5;
        numberOfPowerups = 2;
    }

    public void SetHardDifficulty()
    {
        playerLives = 1;
        playerKeys = 4;
        numberOfEnemies = 10;
        numberOfPowerups = 1;
    }
}
