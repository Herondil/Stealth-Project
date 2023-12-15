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

        if (c.started)
        {
            mAnimator.SetBool("Waking", true);
        }
        if (c.canceled)
        {
            mAnimator.SetBool("Waking", false);
        }
    }

    void Update()
    {
        mAnimator.SetBool("OnGround", _gd.IsGrounded);
    }
}
