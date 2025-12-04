using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tag : MonoBehaviour
{

    [SerializeField] private float tagDistance = 5f;

    Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player != null) {
            return;
        }
        if (Vector3.Distance(player.position, transform.position ) < tagDistance)
        {

            Debug.Log("tagged!");
            SceneManager.LoadScene("GetTaggedScene");

        }
    }


}

