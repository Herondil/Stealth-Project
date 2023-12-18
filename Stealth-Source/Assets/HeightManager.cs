using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component pour régler la hauteur du GameObject du joueur
/// Player.transform.position.y en fait !
/// </summary>
/// 

[RequireComponent(typeof(GroundDetection))]
[RequireComponent(typeof(StepDetector))]
public class HeightManager : MonoBehaviour
{
    private GroundDetection _groundDetector;
    private StepDetector _stepDetector;
    private Rigidbody _rigidbody;

    public Transform[] GroundRayCast;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetection>();
        _stepDetector   = GetComponent<StepDetector>();
        _rigidbody      = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if( _groundDetector.IsGrounded)
        {
            //pas de gravité, on se fixe au sol par un calcul magique
            _rigidbody.useGravity = false;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);

            //on fixe le y à la moyenne de tous les raycast ?



            //Les pied seront placés par les IK
        }
        else
        {
            _rigidbody.useGravity = true;
            //on utilise la gravité pour tomber
        }
    }
}
