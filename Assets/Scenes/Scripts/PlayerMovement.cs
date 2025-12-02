using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(xInput, 0f, yInput).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
}

