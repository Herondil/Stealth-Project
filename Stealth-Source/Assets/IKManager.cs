using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{

    Animator _anim;

    public Transform _headLookAt;
    public Transform _LeftFootPosition;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        Debug.Log("Ik now !");

        //IK de la tête, le poids
        _anim.SetLookAtWeight(1f);

        //IK de la tête, la rotation
        _anim.SetLookAtPosition(_headLookAt.position);

        //pour le pied gauche
        _anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
        _anim.SetIKPosition(AvatarIKGoal.LeftFoot, _LeftFootPosition.position);


    }
}
