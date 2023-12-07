using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 
/// </summary>
public class Sprint : MonoBehaviour
{


    public InputActionAsset IAA;

    //
    private InputAction sprint;

    // Start is called before the first frame update
    void Start()
    {
        sprint = IAA.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
