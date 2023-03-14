using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int maxTowers = 10;
    public int totalMonsterCount = 0;
    public int score = 0;
    public int lives = 8;

    void Start()
    {
        // Find all BuildPlace instances and set their maxTowers value
        Buildplace[] buildPlaces = FindObjectsOfType<Buildplace>();
        foreach (Buildplace buildPlace in buildPlaces)
        {
            buildPlace.maxTowers = maxTowers;
        }

        // Get the total monster count from the SpawnManager script
        Spawn spawnManager = FindObjectOfType<Spawn>();
        if (spawnManager != null)
        {
            totalMonsterCount = spawnManager.GetTotalMonsterCount();
        }
    }

    public void UpdateScore(int monstersKilled)
    {
        score += monstersKilled;
    }

    public void UpdateLives(int livesLost)
    {
        lives -= livesLost;
    }
}
