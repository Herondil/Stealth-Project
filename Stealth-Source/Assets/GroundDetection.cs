using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public float distance;
    public float gravity;
    public LayerMask groundMask; //pour passer à travers les autres masques
    public bool IsGrounded;


    private void OnCollisionStay(Collision collision)
    {
        foreach(ContactPoint contactPoint in collision.contacts)
        {
            Debug.DrawRay(contactPoint.point, contactPoint.normal * 0.5f, Color.blue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.down, out hit, distance,groundMask))
        {
            //on touche le sol 
            IsGrounded = true;
            //Debug.DrawRay(transform.position, hit.normal * distance, Color.magenta);
            //Debug.Log("Angle entre V3.up et la normal de hit "+Vector3.Angle(Vector3.up, hit.normal));
            Debug.DrawRay(transform.position, hit.point, Color.red);
        }
        else
        {
            //on le touche pas
            IsGrounded = false;
            Debug.DrawRay(transform.position, Vector3.down * distance, Color.red);
        }
        
    }
}
