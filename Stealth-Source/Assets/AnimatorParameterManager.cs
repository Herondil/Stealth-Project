using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimatorParameterManager : MonoBehaviour
{
    private Animator mAnimator;

    //convertir les string des noms de paramètres en ID

    public GroundDetection _gd;

    Coroutine c_walkFalse;
    Coroutine c_walkTrue;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void OnSprint(InputAction.CallbackContext c)
    {
        if (c.started)
        {
            mAnimator.SetBool("Sprinting", true);
        }
        if (c.canceled)
        {
            mAnimator.SetBool("Sprinting", false);
        }
    }

    public void OnMove(InputAction.CallbackContext c)
    {
        Vector2 inputs = c.ReadValue<Vector2>();
        mAnimator.SetFloat("Z direction", inputs.y);
        mAnimator.SetFloat("X direction", inputs.x); 

        mAnimator.SetFloat("DirectionMagnitude", inputs.sqrMagnitude);

        if (c.started)
        {
            //mAnimator.SetBool("Waking", true);
            //annuler les coroutines de false
            if(c_walkFalse != null)StopCoroutine(c_walkFalse);
            c_walkTrue = StartCoroutine(WalkingTrue());
        }
        if (c.canceled)
        {
            //mAnimator.SetBool("Waking", false);
            if (c_walkTrue != null) StopCoroutine(c_walkTrue);
            c_walkFalse = StartCoroutine(WalkingFalse());
        }
    }

    void Update()
    {
        mAnimator.SetBool("OnGround", _gd.IsGrounded);
    }

    IEnumerator WalkingTrue()
    {
        yield return new WaitForSeconds(0.5f);
        mAnimator.SetBool("Waking", true);
    }

    IEnumerator WalkingFalse()
    {
        yield return new WaitForSeconds(0.5f);
        mAnimator.SetBool("Waking", false);
    }
}