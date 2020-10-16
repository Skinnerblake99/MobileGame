using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFreeze : MonoBehaviour
{

    public float range = 15f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
