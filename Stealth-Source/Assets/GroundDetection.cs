using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public float distance;
    public float gravity;
    public LayerMask groundMask; //pour passer à travers les autres masques

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, distance,groundMask))
        {
            //on touche le sol 
            Debug.Log("on ground");
        }
        else
        {
            //on le touche pas
        }
        Debug.DrawRay(transform.position, Vector3.down * distance, Color.red);
    }
}
