using System;
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
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetData());
    }
     void Awake()
    {
        covidBoss = GameObject.FindObjectOfType<CovidBoss>();
        StartCoroutine(GetData());   
    }

    IEnumerator GetData()
    {
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
                print(jsonData["body"][5]["newAdmissions"]);
                results = jsonData["body"][5]["newAdmissions"];
                intResults = int.Parse(results);
                covidBoss.CheckBossData(intResults);
                Debug.Log(intResults);
            }

            
        }
    }

    public void ReciveData(int d)
    {
        intResults += d;
    }

    //public static LoadingCovidData CreateFromJSON(string jsonString)
    //{
    //    return JsonUtility.FromJson<LoadingCovidData>(jsonString);
    //}
}
