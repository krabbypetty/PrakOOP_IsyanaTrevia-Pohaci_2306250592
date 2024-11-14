using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        animator = GameObject.Find("EngineEffect")?.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        float screenLimitX = Camera.main.aspect * Camera.main.orthographicSize;
        float screenLimitY = Camera.main.orthographicSize;

        float upperLimit = screenLimitY - 0.5f; 
        float lowerLimit = -screenLimitY;

        float clampedX = Mathf.Clamp(transform.position.x, -screenLimitX, screenLimitX);
        float clampedY = Mathf.Clamp(transform.position.y, lowerLimit, upperLimit);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        
        if (animator != null)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
}