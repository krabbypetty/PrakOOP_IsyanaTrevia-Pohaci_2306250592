using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthComponent healthComponent;

    private void Start()
    {
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.InitializeHealth();
    }

    public void TakeDamage(int damage)
    {
        healthComponent.Subtract(damage);
    }

    public bool IsDead()
    {
        return healthComponent.Health <= 0;
    }
}
