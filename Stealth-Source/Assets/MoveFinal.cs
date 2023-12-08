using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveFinal : MonoBehaviour
{
    [SerializeField]
    float speed;

    Rigidbody rb;
    Vector3 dir;



    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        dir = Vector3.zero;
    }

    /// <summary>
    ///     Pour souscrire à l'évènement de l'action Move
    /// </summary>
    /// <param name="c"></param>
    public void OnMove(InputValue value)
    {
        float y = value.Get<Vector2>().y;
        float x = value.Get<Vector2>().x;
        dir.x = x;
        dir.z = y;
    }



    private void FixedUpdate()
    {
        Debug.Log("FU : x " + dir.x + " y " + dir.y + " z " + dir.z);
        if (dir.sqrMagnitude > 0)
        {
            //rotation 

            rb.MovePosition(transform.position + dir * speed);
        }
    }
}
