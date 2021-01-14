using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class BannerAds : MonoBehaviour
{
    string gameId = "3871599";
    string placementId = "3871599";
    public bool testMode = true;
    public int scene;
    WhichScene ws;
     IEnumerator Start()
    {
        ws = FindObjectOfType<WhichScene>();
        scene = ws.Scene;
        Debug.Log(scene);
        Advertisement.Initialize(gameId, testMode);

        while (!Advertisement.IsReady(placementId))
            yield return null;
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_RIGHT);
            Advertisement.Banner.Show(placementId);
    }

     void Update()
    {
        scene = ws.Scene;
        if(scene == 2)
        {
            Advertisement.Banner.Hide();
        }
        if(scene == 3)
        {
            Advertisement.Banner.Hide();
        }
    }
}
