using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public SpriteRenderer enemySprite;  
    public GameObject bulletPrefab;     
    public Transform firePoint;         
    public float speed = 3f;            
    public float shootInterval = 2f;    
    public float movementRangeX = 5f;   
    private float timeSinceLastShot = 0f; 
    private Vector3 direction = Vector3.left; 
    private bool movingRight = false;  

    void Start()
    {
        if (enemySprite == null)
        {
            enemySprite = GetComponent<SpriteRenderer>();
        }
        
        if (firePoint == null)
        {
            firePoint = transform;
        }
    }

    void Update()
    {
        MoveEnemy();

        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootInterval)
        {
            ShootBullet();
            timeSinceLastShot = 0f;  
        }
    }

    void MoveEnemy()
    {
        if (transform.position.x >= movementRangeX && !movingRight)
        {
            movingRight = true;
            direction = Vector3.right;
            enemySprite.flipX = true;  
        }
        else if (transform.position.x <= -movementRangeX && movingRight)
        {
            movingRight = false;
            direction = Vector3.left;
            enemySprite.flipX = false;  
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }

    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
