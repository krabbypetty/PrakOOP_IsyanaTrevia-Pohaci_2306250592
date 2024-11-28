using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20;
    public int damage { get; private set; } = 10; 

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed; 
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
