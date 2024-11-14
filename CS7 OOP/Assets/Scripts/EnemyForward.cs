using UnityEngine;

public class EnemyForward : MonoBehaviour
{
    public SpriteRenderer enemySprite;  
    public float speed = 5f;            
    public float destroyY = -5f;       
    private Vector3 direction = Vector3.down; 

    void Start()
    {
        if (enemySprite == null)
        {
            enemySprite = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y <= destroyY)
        {
            Destroy(gameObject);  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);  
        }
    }
}
