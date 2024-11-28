using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public int health { get; private set; } 
    void Start()
    {
        InitializeHealth(); 
    }

    public void InitializeHealth()
    {
        health = maxHealth;
    }

    public void Subtract(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
