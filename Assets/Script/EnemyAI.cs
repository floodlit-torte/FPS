using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private Animator animator;

    private NavMeshAgent _agent;
    private float _distanceToTarget;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ChaseTarget();
    }
    private void OnTriggerEnter(Collider other)
    {
        AttackTarget();
    }
    private void OnTriggerStay(Collider other)
    {
        AttackTarget();
    }
    private void AttackTarget()
    {
        animator.SetTrigger("isAttacking");
    }

    private void ChaseTarget()
    {
        _distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (_distanceToTarget < chaseRange)
        {
            _agent.SetDestination(target.position);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
#endif
}
