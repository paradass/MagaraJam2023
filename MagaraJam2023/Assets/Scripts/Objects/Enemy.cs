using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Damage;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Agent();
    }

    void Agent()
    {
        agent.destination = Player.Instance.transform.position;
        agent.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.Instance.Damage(Damage);
            Destroy(gameObject);
        }
        if(other.TryGetComponent<FireBall>(out FireBall fireBall))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
