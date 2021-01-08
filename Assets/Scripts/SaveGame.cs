using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    bool timetoEnd = false;
    //Standard time set to 8 minutes
    public float timer = 480;
    void Start()
    {
        timetoEnd = false;
    }

    void Update()
    {
        if(timer <= 0)
        {
            timetoEnd = true;
        }
    }
}
