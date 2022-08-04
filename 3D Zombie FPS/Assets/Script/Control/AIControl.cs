using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour
{
    [SerializeField] int count = 0;

    NavMeshAgent agent;
    [SerializeField] Transform[] wayPoint;

    private Transform tempPoint = null;
    [SerializeField] int health;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(MoveNext), 0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            CancelInvoke();
            animator.Play("Death");

            Destroy(gameObject, 3);
        }
    }
    public void SetTarget(Transform newTarget)
    {
        CancelInvoke(nameof(MoveNext));
        tempPoint = newTarget;
    }
    public void RemoveTarGet()
    {
        tempPoint = null;
        InvokeRepeating(nameof(MoveNext), 0, 2);
    }

    public void MoveNext()
    {
        if (agent.velocity == Vector3.zero)
        {
            agent.SetDestination(wayPoint[count++].position);

            if (count >= wayPoint.Length)
            {
                count = 0;
            }
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Debug.Log("Ãæµ¹");
            SetTarget(other.transform);

            transform.LookAt(other.transform);

            agent.SetDestination(tempPoint.position);
            
        }
        if (other.CompareTag("Bullet"))
        {
            health -= 30;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            RemoveTarGet();
        }
    }
}
