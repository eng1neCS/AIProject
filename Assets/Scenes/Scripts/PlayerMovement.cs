using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private float speed = 5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Input.GetAxis("Horizontal");
        Input.GetAxis("Vertical");
        GetComponent <Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
