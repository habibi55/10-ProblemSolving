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
    
    public GameObject enemyPrefab;

    private PlayerController _player;
    private List<EnemyController> _currentActiveEnemy = new List<EnemyController>();

    private void Awake()
    {
        _player = FindObjectOfType<PlayerController>();
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

            if (randomPosition.x.Equals(_player.transform.position.x) &&
                randomPosition.y.Equals(_player.transform.position.y))
            {
                randomPosition = RandomizePosition();
            }

            EnemyController enemy = 
                Instantiate(enemyPrefab, randomPosition, 
                    enemyPrefab.transform.rotation).GetComponent<EnemyController>();
            
            _currentActiveEnemy.Add(enemy);
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
