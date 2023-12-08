using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;

    private Rigidbody rb;
    private Vector3 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        Keyboard k      = Keyboard.current;

        if(gamepad != null)
        {
            float y = gamepad.leftStick.y.ReadValue(),
                  x = gamepad.leftStick.x.ReadValue();
            dir = new Vector3(x,0,y);
        }
    }
    private void FixedUpdate()
    {
        if (dir.sqrMagnitude > 0)
        {
            rb.MovePosition(transform.position + dir * speed);
        }
    }
}
