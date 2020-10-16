
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;

    private Transform target;

    private int wavepointIndex = 0;

     void Start()
    {
        target = Waypoints.Points[0];
    }

     void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,target.position)< 0.2f)
        {
            NextMove();
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "FreezeTower")
        {
            speed = 2.5f;
            Debug.Log("Inside tower radius");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "FreezeTower")
        {
            speed = 5f;
            Debug.Log("Left tower radius");
        }
    }

    void NextMove()
    {
        wavepointIndex++;
        target = Waypoints.Points[wavepointIndex];
    }
}
