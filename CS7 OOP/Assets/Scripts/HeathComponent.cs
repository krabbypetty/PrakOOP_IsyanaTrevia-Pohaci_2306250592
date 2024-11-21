using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100; 
    private int health; 

    public int Health
    {
        get { return health; }
    }

    public void Subtract(int damage)
    {
        health -= damage; 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void InitializeHealth()
    {
        health = maxHealth; 
    }
}
