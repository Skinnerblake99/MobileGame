﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using SimpleJSON;
public class LoadingCovidData : MonoBehaviour
{
    public bool Abort = false;
    public string NewData;
    public string _data;
    public string results;
    public int intResults;
    public string www1;
    CovidBoss covidBoss;
    EZMobileBasics ez;
    // Start is called before the first frame update

     void Awake()
    {
        covidBoss = GameObject.FindObjectOfType<CovidBoss>();
        ez = FindObjectOfType<EZMobileBasics>();
        StartCoroutine(GetData());   
    }

    IEnumerator GetData()
    {
        //Data is a week old as its when goverment update it
        //Requests data from UK gov guidance on live infection data
        //Gov data from here https://coronavirus.data.gov.uk/details/download
        www1 = ("https://api.coronavirus.data.gov.uk/v2/data?areaType=overview&metric=newAdmissions&format=json");
        var coronaAPI = new UnityWebRequest(www1)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };
        yield return coronaAPI.SendWebRequest();
        
        if(coronaAPI.isNetworkError || coronaAPI.isHttpError)
        {
            Debug.Log("Theres been either a system networking error or server error");
            Abort = true;
        }
        else
        {
            //Currently think web request location is wrong to retrieve json data from goverment
            JSONNode jsonData = JSON.Parse(coronaAPI.downloadHandler.text);
            if(jsonData == null)
            {
                Debug.Log("Data is null");
            }
            else
            {
                //print(jsonData["body"][7]["newAdmissions"]);
                results = jsonData["body"][7]["newAdmissions"];
                intResults = int.Parse(results);
                Debug.Log(results);
                covidBoss.CheckBossData(intResults);
                //This is for achievment purposes , if NHS england reports 0 new cases in a day
                //Player unlock Beaten the bug achievement on playstore games
                if(intResults == 0)
                {
                    ez.UnlockAchievementBeatenTheBug();
                }
                //Debug.Log(intResults);
            }

            
        }
    }

    public int ReciveData(int d)
    {
        return intResults = d;
    }

}
