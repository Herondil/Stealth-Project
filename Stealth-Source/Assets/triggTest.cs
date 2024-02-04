using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Agent incoming");
    }
}
