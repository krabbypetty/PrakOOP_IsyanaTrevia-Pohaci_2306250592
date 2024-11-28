using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemy; 

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3; 
    public int totalKill = 0; 
    private int totalKillWave = 0; 

    [SerializeField] private float spawnInterval = 3f; 

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0; 
    public int defaultSpawnCount = 1; 
    public int spawnCountMultiplier = 1; 
    public int multiplierIncreaseCount = 1; 

    public CombatManager combatManager; 
    public bool isSpawning = false; 

    private void Start()
    {
        if (!isSpawning)
        {
            StartSpawning();
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        InvokeRepeating(nameof(SpawnEnemies), 0f, spawnInterval); 
    }

    private void SpawnEnemies()
    {

        if (spawnedEnemy == null)
        {
            Debug.LogError("Enemy prefab is not assigned in the Inspector!");
            return;
        }

        for (int i = 0; i < defaultSpawnCount + spawnCountMultiplier; i++)
        {
            Instantiate(spawnedEnemy, GetRandomSpawnPosition(), Quaternion.identity);
            spawnCount++; 
        }

        totalKillWave = 0;
    }

    private Vector2 GetRandomSpawnPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-10f, 10f);
        return new Vector2(x, y); 
    }

    public void IncrementKillCount()
    {
        totalKill++;
        totalKillWave++;

        if (totalKillWave >= minimumKillsToIncreaseSpawnCount)
        {
            spawnCountMultiplier += multiplierIncreaseCount; 
            Debug.Log("Spawn multiplier increased! Current multiplier: " + spawnCountMultiplier);
        }
    }
}
