using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyHorizontalPrefab; 
    public float spawnInterval = 3f; 

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Instantiate(enemyHorizontalPrefab, new Vector3(Random.Range(-10f, 10f), transform.position.y, 0f), Quaternion.identity);
    }
}
