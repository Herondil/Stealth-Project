using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBetter : MonoBehaviour
{
    //Paramétrage de l'inputAction via l'éditeur
    public InputAction Move;

    [SerializeField]
    float speed;

    Rigidbody rb;
    Vector3 dir;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Move.Enable();
        Move.performed += PerformedTest; //pas besoin ?
    }

    
    private void Update()
    {
        float y = Move.ReadValue<Vector2>().y;
        float x = Move.ReadValue<Vector2>().x;
        dir = new Vector3(x, 0, y);
    }
    

    private void FixedUpdate()
    {
        if (dir.sqrMagnitude > 0)
        {
            rb.MovePosition(transform.position + dir * speed);
        }
    }

    private void PerformedTest(InputAction.CallbackContext c)
    {
        Debug.Log("Move performed ");
    }
}
