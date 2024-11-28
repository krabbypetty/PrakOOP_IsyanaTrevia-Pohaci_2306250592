using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Vector2 maxSpeed = new Vector2(7, 7);
    [SerializeField] private Vector2 timeToFullSpeed = new Vector2(0.5f, 0.5f);
    [SerializeField] private Vector2 timeToStop = new Vector2(0.5f, 0.5f);
    [SerializeField] private Vector2 stopClamp = new Vector2(2.5f, 2.5f);

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;
=======
    private Rigidbody2D rb;

    [SerializeField] private Vector2 maxSpeed = new Vector2(7, 5); 
    [SerializeField] private Vector2 timeToFullSpeed = new Vector2(1, 1); 
    [SerializeField] private Vector2 timeToStop = new Vector2(0.5f, 0.5f); 
    [SerializeField] private Vector2 stopClamp = new Vector2(2.5f, 2.5f); 

    private Vector2 moveDirection;
    private float moveVelocityX;
    private float moveVelocityY;
    private float moveFrictionX;
    private float moveFrictionY;
    private float stopFrictionX;
    private float stopFrictionY;
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D tidak ditemukan pada GameObject Player.");
        }

        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
=======


        moveVelocityX = (2 * maxSpeed.x) / timeToFullSpeed.x;
        moveVelocityY = (2 * maxSpeed.y) / timeToFullSpeed.y;
        moveFrictionX = (-2 * maxSpeed.x) / Mathf.Pow(timeToFullSpeed.x, 2);
        moveFrictionY = (-2 * maxSpeed.y) / Mathf.Pow(timeToFullSpeed.y, 2);
        stopFrictionX = (-2 * maxSpeed.x) / Mathf.Pow(timeToStop.x, 2);
        stopFrictionY = (-2 * maxSpeed.y) / Mathf.Pow(timeToStop.y, 2);
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
    }

    public void Move()
    {
<<<<<<< HEAD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Debug.Log("Horizontal Input: " + horizontalInput); // Debug input horizontal
        Debug.Log("Vertical Input: " + verticalInput);     // Debug input vertical

        moveDirection = new Vector2(horizontalInput, verticalInput);
        Debug.Log("Move Direction: " + moveDirection); // Debug untuk memeriksa arah gerak

        if (moveDirection != Vector2.zero)
        {
            Debug.Log("Before Movement Velocity: " + rb.velocity); // Debug sebelum pergerakan
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + moveDirection * moveVelocity * Time.fixedDeltaTime, maxSpeed.magnitude);
            Debug.Log("After Movement Velocity: " + rb.velocity); // Debug setelah pergerakan
        }
        else
        {
            Vector2 friction = GetFriction();
            rb.velocity = Vector2.ClampMagnitude(rb.velocity + friction * Time.fixedDeltaTime, stopClamp.magnitude);
        }
    }

    private Vector2 GetFriction()
    {
        return moveDirection != Vector2.zero ? moveFriction : stopFriction;
    }

    private void MoveBound()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f); // Sesuaikan dengan batas layar game Anda
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f); // Sesuaikan dengan batas layar game Anda
        transform.position = pos;
=======
        float inputX = 0f;
        float inputY = 0f;

        if (Input.GetKey(KeyCode.W)) inputY = 1f; 
        if (Input.GetKey(KeyCode.S)) inputY = -1f; 
        if (Input.GetKey(KeyCode.D)) inputX = 1f; 
        if (Input.GetKey(KeyCode.A)) inputX = -1f; 


        moveDirection = new Vector2(inputX, inputY).normalized;

        rb.velocity = moveDirection * maxSpeed.x; 
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
    }

    public bool IsMoving()
    {
<<<<<<< HEAD
        return moveDirection != Vector2.zero;
=======
        return rb.velocity.magnitude > stopClamp.magnitude;
>>>>>>> 3faabe5 (CS_IsyanaTreviaPohaci_@306250592_OOP11)
    }
}
