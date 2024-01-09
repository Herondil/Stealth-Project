using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path : MonoBehaviour
{
    NavMeshAgent _agent;
    public Transform destination1;
    public Transform destination2;

    bool ping = true;

    //pour pouvoir mettre en pause la patrouille facilement
    public bool onPause;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agent.SetDestination(destination1.position);
        Vector3 trueDestination = _agent.destination;
        onPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onPause)
        {
            _agent.isStopped = false;
            if (_agent.remainingDistance == 0)
            {
                if (ping)
                {   
                    _agent.SetDestination(destination2.position);
                    ping = false;
                }
                else
                {
                    _agent.SetDestination(destination1.position);
                    ping = true;
                }
            }

        }
        else
        {
            _agent.isStopped = true;
        }
        
    }
}
