using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExemple : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Debug.Log(Physics.Raycast(transform.position, Vector3.right));
        Debug.DrawRay(transform.position, Vector3.right * 1000, Color.red);
    }
}
