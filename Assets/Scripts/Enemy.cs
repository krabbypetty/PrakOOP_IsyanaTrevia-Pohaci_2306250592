using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;

    void Start()
    {
        if (healthComponent != null)
        {
            healthComponent.InitializeHealth();
        }
    }

    void Update()
    {
        if (healthComponent != null && healthComponent.health <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
