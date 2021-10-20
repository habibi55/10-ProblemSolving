using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject littleBoxPrefab;

    private void Start()
    {
        RandomSpawnBox();
    }

    private void RandomSpawnBox()
    {
        int numberOfBox = Random.Range(1, 10);

        for (int i = 0; i < numberOfBox; i++)
        {
            Vector2 randomPosition = RandomizePosition();

            Instantiate(littleBoxPrefab, randomPosition, littleBoxPrefab.transform.rotation);
        }
    }

    private Vector2 RandomizePosition()
    {
        float randomXAxis = Random.Range(-2.75f, 2.75f);
        float randomYAxis = Random.Range(-2.75f, 2.75f);

        return new Vector2(randomXAxis, randomYAxis);
    }
}
