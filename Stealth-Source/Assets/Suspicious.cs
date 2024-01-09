using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspicious : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //bark "que se passe-t-il ?"

        //patrouille en pause
        animator.gameObject.GetComponentInParent<Path>().onPause = true;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Si le joueur n'est pas trouvé pendant un certain temps, on reprend la patrouille

        //le joueur est trouvé si on le touche avec un ray ? pendant un certain temps dans son cône de vision

        //le joueur est trouvé si dans la sphère avec un certain score de bruit

        //quand le raycast touche le joueur, on reset le timer de reprise de la patrouille
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
