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

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        RandomSpawnEnemy();
    }

    private void RandomSpawnEnemy()
    {
        int numberOfBox = Random.Range(1, 10);

        for (int i = 0; i < numberOfBox; i++)
        {
            Vector2 randomPosition = RandomizePosition();

            while (randomPosition.x <= player.transform.position.x + 0.757f ||
                   randomPosition.y <= player.transform.position.y + 0.757f)
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
        float randomXAxis = Random.Range(-2.75f, 2.75f);
        float randomYAxis = Random.Range(-2.75f, 2.75f);
        
        Vector2 spawnPosition = new Vector2(randomXAxis, randomYAxis);
        
        return spawnPosition;
    }
}
