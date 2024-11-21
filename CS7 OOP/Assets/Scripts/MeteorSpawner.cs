using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject meteorPrefab;   
    public float spawnInterval = 2f;   
    public float spawnRangeX = 8f;     

    private float timer;               

    void Start()
    {
        timer = 0f; 
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMeteor();    
            timer = 0f;       
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), transform.position.y, 0);
        
        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }
}
