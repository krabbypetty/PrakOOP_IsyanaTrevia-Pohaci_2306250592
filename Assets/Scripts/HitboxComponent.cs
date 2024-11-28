using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health; 
    private Collider2D area; 
    private InvincibilityComponent invincibilityComponent; 

    void Start()
    {
        area = GetComponent<Collider2D>();
        invincibilityComponent = GetComponent<InvincibilityComponent>();
    }

    public void Damage(Bullet bullet)
    {
        if (invincibilityComponent != null && invincibilityComponent.isInvincible) return;

        if (health != null)
            health.Subtract(bullet.damage);

        if (invincibilityComponent != null)
            invincibilityComponent.TriggerInvincibility();
    }

    public void Damage(int damage)
    {
        if (invincibilityComponent != null && invincibilityComponent.isInvincible) return;

        if (health != null)
            health.Subtract(damage);

        if (invincibilityComponent != null)
            invincibilityComponent.TriggerInvincibility();
    }
}
