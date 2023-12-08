using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBest : MonoBehaviour
{
    //un scriptable object
    public InputActionAsset IAA;

    //en privé ! 
    private InputAction Move;

    [SerializeField]
    float speed;

    Rigidbody rb;
    Vector3 dir;

    void Awake()
    {
        //copié de la doc
        Move = IAA.FindActionMap("default").FindAction("Move");
        
        
        Move.Enable();

        rb = GetComponent<Rigidbody>();
        Move.performed += PerformedTest; //pas besoin ?
    }

    // Update is called once per frame
    void Update()
    {
        float y = Move.ReadValue<Vector2>().y;
        float x = Move.ReadValue<Vector2>().x;

        dir = new Vector3(x, 0, y);
    }
    private void FixedUpdate()
    {
        if (dir.sqrMagnitude > 0)
        {
            //rotation 

            rb.MovePosition(transform.position + dir * speed);
        }
    }

    private void PerformedTest(InputAction.CallbackContext c)
    {
        Debug.Log("Move performed ");
    }
}
