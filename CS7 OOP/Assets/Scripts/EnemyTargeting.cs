using UnityEngine;

public class EnemyTargeting : MonoBehaviour
{
    public SpriteRenderer enemySprite;    
    public float speed = 3f;              
    public float attackRange = 1f;        
    public Transform player;             

    private Vector3 direction;            

    void Start()
    {
        if (enemySprite == null)
        {
            enemySprite = GetComponent<SpriteRenderer>();
        }
        
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        MoveTowardsPlayer();

        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            Destroy(gameObject);
        }
    }

    void MoveTowardsPlayer()
    {
        direction = (player.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        if (direction.x < 0)
        {
            enemySprite.flipX = false;  
        }
        else
        {
            enemySprite.flipX = true;   
        }
    }
}
