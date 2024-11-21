using UnityEngine;

public class Player : MonoBehaviour
{
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
    }

    void FixedUpdate()
    {
        if (playerMovement != null)
        {
            playerMovement.Move();
        }
    }

    void LateUpdate()
    {
        if (animator != null && playerMovement != null)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
}
