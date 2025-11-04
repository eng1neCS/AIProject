using UnityEngine;
using UnityEngine.AI;

public class NavManager : MonoBehaviour
{
    
    public Transform player;
    private UnityEngine.AI.NavMeshAgent agent;
    private int currentPatrolIndex;

    [SerializeField] float sightRange = 10f;
    [SerializeField] float viewAngle = 80f;
    [SerializeField] float patrolSpeed = 3.5f;
    public Transform[] patrolPoints;
    private bool chasingPlayer = false;


    enum State
    {
        Patrolling,
        Chasing,
        Searching,
        Attacking,
        Dying,
        Dead
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (patrolPoints.Length > 0)
        {
            agent.speed = patrolSpeed;
            agent.SetDestination(patrolPoints[0].position);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player == null)
        {
            return;
        }
        
        Debug.DrawLine(transform.position, player.position, Color.blue);
        Vector3 rightside = Quaternion.AngleAxis(viewAngle, Vector3.up) * transform.forward;
        Vector3 leftside = Quaternion.AngleAxis(-viewAngle, Vector3.up) * transform.forward;
        Debug.DrawLine(transform.position, transform.position + (rightside * sightRange), Color.red);
        Debug.DrawLine(transform.position, transform.position + (leftside * sightRange), Color.red);
        RaycastHit hit;


        if (Physics.Raycast(transform.position, player.position-transform.position, out hit, sightRange))
        {
            if(hit.transform == player)
            {
                if(Vector3.Dot(player.position - transform.position, transform.forward)
                    >= Mathf.Cos(viewAngle))
                {
                    chasingPlayer = true;
                    agent.SetDestination(player.position);
                    Debug.Log("Player in sight");
                }
            }
            else
            {
                if (chasingPlayer)
                {
                    chasingPlayer = false;
                    agent.speed = patrolSpeed;
                    agent.SetDestination(patrolPoints[currentPatrolIndex].position);
                }
                
            }
        }
        else
        {
            Patrol();
        }
    }


    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;     
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }
}
