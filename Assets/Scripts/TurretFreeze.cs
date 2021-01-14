using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFreeze : MonoBehaviour
{

    public float range = 15f;
     void Start()
    {
        //Move tower to offset on tile pos
        //this.gameObject.transform.localPosition = new Vector3(1, 1,1);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
