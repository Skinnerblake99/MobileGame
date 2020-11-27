using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnLocation;
    public GameObject EnemySpawned;
    public float TimeBetweenSpawn = 50f;
    public float TimesHasBeenInvoked;
    public Vector3 NewSpawn = new Vector3(0f, 0f, 0f);
    void Start()
    {
        InvokeRepeating("Spawn", 20f, 1f);
    }

     void Update()
    {
        TimeBetweenSpawn += Time.deltaTime;
    }

    //Might need to tweak with numbers but game gets progressivley harder as spawn times reduce 
    void Spawn()
    {
        if (TimeBetweenSpawn >= 30)
        {
            Instantiate(EnemySpawned,SpawnLocation);
            TimesHasBeenInvoked += 1;
            TimeBetweenSpawn = 0;
            TimeBetweenSpawn += TimesHasBeenInvoked;
            //Debug.Log(TimeBetweenSpawn);
        }
        else return;
    }

}
