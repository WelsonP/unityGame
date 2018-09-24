using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSpawner : MonoBehaviour {

    public GameObject mario_fish;

    float MaxSpawnRateInSeconds = 2f;
    float VerticalAdjustment = 0.2f;

	// Use this for initialization
	void Start () {
        Invoke("SpawnEnemy", MaxSpawnRateInSeconds);

        // increase spawn rate every 30 seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //instantiate an Enemy
        GameObject anEnemy = (GameObject)Instantiate(mario_fish);
        mario_fish.transform.position = new Vector2(max.x, Random.Range(VerticalAdjustment * max.y, max.y));

        ScheduleNextEnemySpawn(); 
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (MaxSpawnRateInSeconds > 1f)
        {
            // pick a number between 1  and maxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(1f, MaxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    // function to in crease difficulty
    void IncreaseSpawnRate()
    {
        if (MaxSpawnRateInSeconds > 1f)
        {
            MaxSpawnRateInSeconds--;
        } 
        if (MaxSpawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
