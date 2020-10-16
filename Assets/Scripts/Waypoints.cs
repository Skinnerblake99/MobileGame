using UnityEngine;

public class Waypoints : MonoBehaviour
{
    //Blake Skinner 07/10/2020 used tutorial for how to setup navigation youtube.com/watch?v=aFxucZQ_5E4&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=2
    public static  Transform[] Points;

     void Awake()
    {
        Points = new Transform[transform.childCount];
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] = transform.GetChild(i);
        }
    }
}
