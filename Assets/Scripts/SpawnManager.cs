using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject littleBoxPrefab;

    private PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        RandomSpawnBox();
    }
    
    private void RandomSpawnBox()
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
            
            Instantiate(littleBoxPrefab, randomPosition, littleBoxPrefab.transform.rotation);
        }
    }

    private Vector2 RandomizePosition()
    {
        float randomXAxis = Random.Range(-2.75f, 2.75f);
        float randomYAxis = Random.Range(-2.75f, 2.75f);
        
        Vector2 spawnPosition = new Vector2(randomXAxis, randomYAxis);
        
        return spawnPosition;
    }
}
