using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepDetector : MonoBehaviour
{
    //Le point de départ du ray qui sert à détecter la marche
    public Transform StepDetectorRayStartingPoint;

    //les positions du sol et de la marche, on fera la différence en Y pour savoir la hauteur
    private Vector3 floorPosition;
    private Vector3 stepPosition;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitFloor;

        //Ray qui part du pivot vers le bas, sur une distance
        if (Physics.Raycast(transform.position, Vector3.down, out hitFloor, 0.3f))
        {
            Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.magenta);
            floorPosition = hitFloor.point;
        }

        RaycastHit hitStep;

        //Ray qui part d'un point donné, devant la capsule, vers le bas, sur une distance arbitraire
        if (Physics.Raycast(StepDetectorRayStartingPoint.position, Vector3.down, out hitStep, 2f))
        {
            Debug.DrawRay(StepDetectorRayStartingPoint.position, Vector3.down * 2f, Color.magenta);
            stepPosition = hitStep.point;
        }

        //Debug.Log("Hauteur de la marche devant : " + (stepPosition.y - floorPosition.y));
    }
}
