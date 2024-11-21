using UnityEngine;

[RequireComponent(typeof(Collider))] 
public class HitboxComponent : MonoBehaviour
{
    private HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();

        if (healthComponent == null)
        {
            Debug.LogError("HealthComponent is missing from this object!");
        }
    }

    public void Damage(Bullet bullet)
    {
        if (bullet != null)
        {
            int damage = bullet.GetDamage(); 
            healthComponent.Subtract(damage);
        }
    }

    public void Damage(int damage)
    {
        healthComponent.Subtract(damage); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            Damage(bullet);
        }
        else
        {
            int damage = 10; 
            Damage(damage);
        }
    }
}
