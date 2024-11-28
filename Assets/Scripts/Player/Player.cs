using UnityEngine;

public class Player : MonoBehaviour
{
<<<<<<< HEAD
    public static Player Instance;

    private PlayerMovement playerMovement;
    private Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement tidak ditemukan pada GameObject Player.");
        }

        Transform engineTransform = transform.Find("Engine");
        if (engineTransform == null)
        {
            Debug.LogError("GameObject Engine tidak ditemukan di dalam Player.");
        }
        else
        {
            Transform engineEffectTransform = engineTransform.Find("EngineEffect");
            if (engineEffectTransform == null)
            {
                Debug.LogError("GameObject EngineEffect tidak ditemukan di dalam Engine.");
            }
            else
            {
                animator = engineEffectTransform.GetComponent<Animator>();
                if (animator == null)
                {
                    Debug.LogError("Animator tidak ditemukan pada GameObject EngineEffect.");
                }
            }
        }
=======
    private PlayerMovement playerMovement;
    private Animator animator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        animator = GameObject.Find("EngineEffect")?.GetComponent<Animator>();
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
    }

    void FixedUpdate()
    {
<<<<<<< HEAD
        if (playerMovement != null)
        {
            playerMovement.Move();
        }
=======
        playerMovement.Move();
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
    }

    void LateUpdate()
    {
<<<<<<< HEAD
        if (animator != null && playerMovement != null)
=======
        float screenLimitX = Camera.main.aspect * Camera.main.orthographicSize;
        float screenLimitY = Camera.main.orthographicSize;

        float upperLimit = screenLimitY - 0.5f; 
        float lowerLimit = -screenLimitY;

        float clampedX = Mathf.Clamp(transform.position.x, -screenLimitX, screenLimitX);
        float clampedY = Mathf.Clamp(transform.position.y, lowerLimit, upperLimit);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        
        if (animator != null)
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
