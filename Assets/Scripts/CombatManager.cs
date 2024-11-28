using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;  
        public int waveNumber = 1;  

    [SerializeField] private float waveInterval = 5f;  
    public int totalEnemies = 0;  
    private float timer = 0f;  

    private void Start()
    {
        StartWave();  
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waveInterval)
        {
            timer = 0f;  
            EndWave(); 
            StartWave();  
        }
    }

    private void StartWave()
    {
        Debug.Log($"Starting Wave {waveNumber}");

        foreach (var spawner in enemySpawners)
        {
            spawner.defaultSpawnCount = waveNumber;
            spawner.spawnCountMultiplier = waveNumber;
            spawner.StartSpawning(); 
        }

        waveNumber++;  
    }

    private void EndWave()
    {
        Debug.Log($"Ending Wave {waveNumber - 1}");
    }
}
