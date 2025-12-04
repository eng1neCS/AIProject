using UnityEngine;

public class Player : MonoBehaviour
{
    // Ground Movement
    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(moveHorizontal ,0, moveForward).normalized * MoveSpeed;

        movement.y = rb.linearVelocity.y; // Preserve vertical velocity (e.g., gravity)
        rb.linearVelocity = movement;
    }
}
