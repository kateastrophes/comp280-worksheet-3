using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SpiderPatrol : MonoBehaviour
{

    // COMPONENTS
    private NavMeshAgent agent;
    private Animator anim;

    // CHANGEABLE
    [SerializeField] private float attackRadius;
    [SerializeField] private float chaseRadius;
    public float moveSpeed;
    public float waitDelay;

    // WAYPOINTS
    public Transform[] points;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        agent.autoBraking = false;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        destPoint = (destPoint + 1) % points.Length;
        if (points.Length == 0)
            return;
        // Set destination to be the next waypoint.
        agent.destination = points[destPoint].position;
        // Set animation to walk forwards.
        anim.SetBool("WalkForwards", true);
    }

    void Update()
    {
        bool isNearbyPlayer = IsPlayerNear();
        // If the spider is not close to the player, check the distance to the waypoint.
        // When the spider has reached the way point, begin PointDelay.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isNearbyPlayer)
        {
            StartCoroutine(PointDelay());
        }
        // Begin chase function when player is close enough.
        if (isNearbyPlayer)
        {
            Chase();
        }
    }

    IEnumerator PointDelay()
    {
        // Make the spider wait for 10 seconds befor moving on the next waypoint.
        anim.SetBool("WalkForwards", false);
        yield return new WaitForSeconds(waitDelay);
        GotoNextPoint();
        Debug.Log("Delaying");
    }

    bool IsPlayerNear()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, chaseRadius);
        foreach (Collider item in nearbyObjects)
        {
            if (item.CompareTag("Player"))
            {
                target = item.transform;
                Debug.Log("Player near is true.");
                return true;
            }
        }
        return false;
    }

    void Chase()
    {
        bool canAttackPlayer = CanAttackPlayer();
        Vector3 newTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        agent.destination = newTargetPostition;
        Debug.Log("Is Chasing");
        if (canAttackPlayer)
        {
            Attack();
        }
    }

    bool CanAttackPlayer()
    {
        // For each object that is found within a sphere surrounding the spider, check if the object is the player.
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider item in nearbyObjects)
        {
            if (item.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    void Attack()
    {
        // Set the animation for the spider to attack.
        anim.SetBool("Attack", true);
        Debug.Log("Player being attacked");
    }

    private void OnDrawGizmos()
    {
        // Radius for attacking the player.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
        // Radius for chasing the player.
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, chaseRadius);
    }
}