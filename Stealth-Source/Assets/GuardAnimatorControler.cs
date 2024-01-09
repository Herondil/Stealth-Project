using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAnimatorControler : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    [SerializeField]
    float SprintThreshlold;

    [SerializeField]
    float WalkingThreshlold;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //sprinting
        if(agent.velocity.magnitude >= SprintThreshlold)
        {
            animator.SetBool("Sprinting", true);
        }
        else
        {
            animator.SetBool("Sprinting", false);
        }

        //walking
        if(agent.velocity.magnitude > 0)
        {
            animator.SetBool("Waking", true);
        }
        else
        {
            animator.SetBool("Waking", false);
        }
    }
}
