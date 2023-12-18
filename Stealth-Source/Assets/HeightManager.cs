using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component pour r�gler la hauteur du GameObject du joueur
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
            //pas de gravit�, on se fixe au sol par un calcul magique
            _rigidbody.useGravity = false;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);

            //on fixe le y � la moyenne de tous les raycast ?



            //Les pied seront plac�s par les IK
        }
        else
        {
            _rigidbody.useGravity = true;
            //on utilise la gravit� pour tomber
        }
    }
}
