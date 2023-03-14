using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour {
// The Monster prefabs that can be spawned
public List<GameObject> monsterPrefabs = new List<GameObject>();

// The number of each monster type that will be spawned
public int[] monsterCounts;

// The order in which the monsters will be spawned
public int[] monsterOrder;

// Spawn Delay in seconds
public float interval = 3;

// Index to keep track of which monster to spawn next
private int monsterIndex = 0;

// Use this for initialization
void Start() {
    InvokeRepeating("SpawnNext", interval, interval);
}

void SpawnNext() {
    // If we have spawned all monsters, cancel the spawn
    if (monsterIndex >= monsterOrder.Length) {
        CancelInvoke("SpawnNext");
        return;
    }

    // Get the index of the next monster type to spawn
    int nextMonsterTypeIndex = monsterOrder[monsterIndex];

    // Instantiate the next monster type at the spawn position
    Instantiate(monsterPrefabs[nextMonsterTypeIndex], transform.position, Quaternion.identity);

    // Decrement the count of the next monster type
    monsterCounts[nextMonsterTypeIndex]--;

    // If we have spawned all of this monster type, move on to the next type
    if (monsterCounts[nextMonsterTypeIndex] == 0) {
        monsterIndex++;
    }
}

    internal int GetTotalMonsterCount()
    {
        return monsterCounts.Sum();
    }
}