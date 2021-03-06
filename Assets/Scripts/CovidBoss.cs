﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidBoss : MonoBehaviour
{
    //This is covid boss and health and power of the boss is based directly on virus infection data loaded in from a goverment website
    //API data loaded from the networking data gameobject which connects to the gov api
    // Start is called before the first frame update
    //This boss is just tanky dependent on daily infection data which is  a week old
    LoadingCovidData loadingCovidData;
    public int bossMod;
    public bool justStarted = true;
    public float bossHealth = 200;
    public bool hasRecievedBonus;
    //Super important this data is loaded in awake due to priortiy
    void Awake()
    {
        loadingCovidData = GameObject.FindObjectOfType<LoadingCovidData>();
        CheckBossData(bossMod);
    }
     void Start()
    {
         justStarted = true;
         hasRecievedBonus = false;
    }
    public int CheckBossData(int d)
    {
        loadingCovidData.ReciveData(d);
        bossMod = loadingCovidData.ReciveData(d);
        Debug.Log(bossMod);
        return d;
    }
    // Update is called once per frame
    void Update()
    {
        if(bossHealth <=0 && hasRecievedBonus)
        {
            Die();
        }
        
    }

    void addHealth()
    {
        bossHealth = bossMod;
    }

    void OnTriggerEnter(Collider other)
    {
        //Have had to x4 the damage 13/01/2021 to see if this can help fix the boss being too strong
        if (other.tag == "Bullet")
        {
            bossHealth -= 200;
            if (bossHealth <=0 && !hasRecievedBonus)
            {
                addHealth();
                hasRecievedBonus = true;
            }
        }

        if (other.tag == "EndPoint")
        {
            ReachedTarget();
        }

    }

    //Below manages logic for killing when either at end or if runs out of health
    void Die()
    {
        ScoreManager.Score += 10;
        Destroy(gameObject);
    }

    void ReachedTarget()
    {
        PlayerHealth.Health -= 1;
        Destroy(gameObject);
    }
}
