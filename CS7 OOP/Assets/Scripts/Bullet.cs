using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Properties")]
    [SerializeField] private int damage = 10;  
    [SerializeField] private float speed = 10f;  
    [SerializeField] private float lifetime = 5f;  
    [SerializeField] private Rigidbody rb;  
    public int GetDamage()
    {
        return damage;
    }

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        if (rb != null)
        {
            rb.velocity = transform.forward * speed; 
        }

        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitboxComponent hitbox = collision.gameObject.GetComponent<HitboxComponent>();

        if (hitbox != null)
        {
            hitbox.Damage(this);  
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HitboxComponent hitbox = other.gameObject.GetComponent<HitboxComponent>();

        if (hitbox != null)
        {
            hitbox.Damage(this);  
        }

        Destroy(gameObject);
    }
}
