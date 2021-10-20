using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance = null;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SpawnManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("SpawnManager not found!");
            }

            return _instance;
        }
    }
    
    public GameObject littleBoxPrefab;

    private PlayerController player;
    private List<EnemyController> currentActiveEnemy = new List<EnemyController>();
    private float nonSpawnableArea = 1f;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        RandomSpawnEnemy();
    }

    private void RandomSpawnEnemy()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }

        int numberOfBox = Random.Range(5, 10);

        for (int i = 0; i < numberOfBox; i++)
        {
            Vector2 randomPosition = RandomizePosition();

            if (randomPosition.x.Equals(player.transform.position.x) &&
                randomPosition.y.Equals(player.transform.position.y))
            {
                randomPosition = RandomizePosition();
            }

            EnemyController enemy = 
                Instantiate(littleBoxPrefab, randomPosition, 
                    littleBoxPrefab.transform.rotation).GetComponent<EnemyController>();
            
            currentActiveEnemy.Add(enemy);
        }
    }

    public Vector2 RandomizePosition()
    {
        float randomXAxis = Random.Range(-3f, 3f);
        float randomYAxis = Random.Range(-3f, 3f);
        
        Vector2 spawnPosition = new Vector2(randomXAxis, randomYAxis);
        
        return spawnPosition;
    }
}
