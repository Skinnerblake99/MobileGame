using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidBoss : MonoBehaviour
{
    //This is covid boss and health and power of the boss is based directly on virus infection data loaded in from a goverment website
    //API data loaded from the networking data gameobject which connects to the gov api
    // Start is called before the first frame update
    LoadingCovidData loadingCovidData;
    public int bossMod;
    //Super important this data is loaded in awake due to priortiy
    void Awake()
    {
        loadingCovidData = GameObject.FindObjectOfType<LoadingCovidData>();
        CheckBossData(bossMod);
    }
    public void CheckBossData(int d)
    {
        loadingCovidData.ReciveData(d);
        bossMod = d;
    }
    // Update is called once per frame
    void Update()
    {
    }
}
