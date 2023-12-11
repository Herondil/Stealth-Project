using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFinal : MonoBehaviour
{
    [SerializeField]
    float speed;

    private Rigidbody rb;
    private Vector3 dir;

    //public Vector2 m_move;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        dir = Vector3.zero;
    }

    /// <summary>
    ///     Pour souscrire à l'évènement de l'action Move
    /// </summary>
    /// <param name="c"></param>

    public void OnMove(InputAction.CallbackContext c)
    {
        //m_move = c.ReadValue<Vector2>();
        if (c.performed)
        {
            float y = c.ReadValue<Vector2>().y;
            float x = c.ReadValue<Vector2>().x;
            dir.x = x;
            dir.z = y;
           // Debug.Log("OnMove Performed : x " + dir.x + " y " + dir.y + " z " + dir.z);
        }
    }



    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate : x " + dir.x + " y " + dir.y + " z " + dir.z);
       // Debug.Log("FixedUpdate : x " + m_move.x + " y " + m_move.y );
        if (dir.sqrMagnitude > 0)
        {
            //rotation 

            rb.MovePosition(transform.position + dir * speed);
        }
    }

    private void LateUpdate()
    {
        
        //Debug.Log("LateUpdate : x " + dir.x + " y " + dir.y + " z " + dir.z);
    }
}
