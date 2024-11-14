using UnityEngine;

public class EnemyHorizontal : Enemy
{
    private Rigidbody2D rb;
    private float moveSpeed = 2f;

    private bool isMovingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isMovingRight = Random.Range(0, 2) == 0;
    }

    private void Update()
    {
        if (isMovingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (transform.position.x > Screen.width || transform.position.x < 0)
        {
            isMovingRight = !isMovingRight;
        }
    }

}
