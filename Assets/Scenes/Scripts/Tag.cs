using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tag : MonoBehaviour
{

    [SerializeField] private float tagDistance = 10f;

    Transform Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (Player != null) {
            return;
        }

        if (Vector3.Distance(Player.position, transform.position ) < tagDistance)
        {

            Debug.Log("tagged!"); 
            SceneManager.LoadScene("GetTaggedScene");

        }
    }


}

