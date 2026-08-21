using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public Transform target;           // 指向拱門
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.avoidancePriority = Random.Range(10, 50);
    }

    void Update()
    {
        agent.SetDestination(target.position);

        // 距離很近還沒進 Trigger 時，強制重找路
        if (agent.remainingDistance <= 0.3f && !agent.pathPending)
            agent.ResetPath();
    }
    public void Die()
    {
        Destroy(gameObject); // 讓怪獸消失
    }

}
