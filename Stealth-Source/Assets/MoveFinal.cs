using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFinal : MonoBehaviour
{
    [SerializeField]
    float walkingSpeed;
    [SerializeField]
    float sprintingSpeed;

    //la vitesse utilisée actuellement (soit walking soit sprinting speed)
    private float currentSpeed;

    Rigidbody rb;
    Vector2 inputDir;
    Vector3 moveDir;
    Quaternion rot;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputDir = Vector3.zero;
        currentSpeed = walkingSpeed;
    }

    public void OnMove(InputAction.CallbackContext c)
    {
        if (c.performed) {
            currentSpeed = walkingSpeed;
            float y = c.ReadValue<Vector2>().y;
            float x = c.ReadValue<Vector2>().x;
            inputDir.x = x;
            inputDir.y = y;
        }

        if (c.canceled) inputDir = Vector3.zero;
    }

    public void OnSprint(InputAction.CallbackContext c)
    {
        if (c.started)
        {
            currentSpeed = sprintingSpeed;
        }
        if (c.canceled)
        {
            currentSpeed = walkingSpeed;
        }
    }
    private void FixedUpdate()
    {
        //on récupère cameraForward dans une variable pour corriger son y, pour être "parallèle" au sol
        //idem pour cameraRight
        Vector3 cameraForward   = Camera.main.transform.forward;
        Vector3 cameraRight     = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        //on fait une rotation à chaque fixedUpdate pour vérifier qu'on a bien la bonne direction
        /*
        rot = Quaternion.LookRotation(cameraForward);
        rb.MoveRotation(rot);
        */
        //moveDir sera la direction finale du déplacement
        moveDir = Vector3.zero;

        if (inputDir.sqrMagnitude > 0)
        {
            //on va multiplier la direction "forward" de la caméra par l'input en y
            //on sait ainsi si on avance ou si on recule
            Vector3 moveForward = cameraForward * inputDir.y;

            //même raisonnement pour gauche/droite
            Vector3 moveRight   = cameraRight * inputDir.x;

            //on veut aller en même temps dans les deux directions
            moveDir = moveForward + moveRight;
            
            //rotation 
            rb.MovePosition(transform.position + moveDir.normalized * currentSpeed);
        }
    }
}