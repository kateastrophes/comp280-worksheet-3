using UnityEngine;
using UnityEngine.AI;

public class SpiderChase : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Animator anim;
    [SerializeField] public float attackRadius;

    private NavMeshAgent agent;

    private bool inPLay = false;
    private bool attacking;
 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        bool canAttackPlayer = CanAttackPlayer();
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("DigEmerge")) inPLay = true;

        if (inPLay)
        {
            Vector3 newTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            agent.destination = newTargetPostition;
            Debug.Log("Is chasing the player.");
            anim.SetBool("WalkForwards", true);
            if (attacking)
            {
                anim.SetBool("Attack", false);
                attacking = false;
            }
            if (canAttackPlayer)
            {
                AttackPlayer();
            }
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

    void AttackPlayer()
    {
        // Set the animation for the spider to attack.
        attacking = true;
        anim.SetBool("Attack", true);
        Debug.Log("Player being attacked");
    }
    private void OnDrawGizmos()
    {
        // Radius for attacking the player.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
    }
}