using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Vector2 maxSpeed = new Vector2(7, 5); // Kecepatan maksimum untuk X dan Y
    [SerializeField] private Vector2 timeToFullSpeed = new Vector2(1, 1); // Waktu untuk mencapai kecepatan maksimum
    [SerializeField] private Vector2 timeToStop = new Vector2(0.5f, 0.5f); // Waktu untuk berhenti
    [SerializeField] private Vector2 stopClamp = new Vector2(2.5f, 2.5f); // Batas kecepatan minimum sebelum berhenti

    private Vector2 moveDirection;
    private float moveVelocityX;
    private float moveVelocityY;
    private float moveFrictionX;
    private float moveFrictionY;
    private float stopFrictionX;
    private float stopFrictionY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


        moveVelocityX = (2 * maxSpeed.x) / timeToFullSpeed.x;
        moveVelocityY = (2 * maxSpeed.y) / timeToFullSpeed.y;
        moveFrictionX = (-2 * maxSpeed.x) / Mathf.Pow(timeToFullSpeed.x, 2);
        moveFrictionY = (-2 * maxSpeed.y) / Mathf.Pow(timeToFullSpeed.y, 2);
        stopFrictionX = (-2 * maxSpeed.x) / Mathf.Pow(timeToStop.x, 2);
        stopFrictionY = (-2 * maxSpeed.y) / Mathf.Pow(timeToStop.y, 2);
    }

    public void Move()
    {
        // Mengambil input dari keyboard
        float inputX = 0f;
        float inputY = 0f;

        if (Input.GetKey(KeyCode.W)) inputY = 1f; 
        if (Input.GetKey(KeyCode.S)) inputY = -1f; 
        if (Input.GetKey(KeyCode.D)) inputX = 1f; 
        if (Input.GetKey(KeyCode.A)) inputX = -1f; 

        //Debug.Log("Input X: " + inputX + ", Input Y: " + inputY);

        moveDirection = new Vector2(inputX, inputY).normalized;

        rb.velocity = moveDirection * maxSpeed.x; 
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > stopClamp.magnitude;
    }
}
