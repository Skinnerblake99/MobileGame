using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    string gameId = "3871599";
    string placementId = "3871599";
   public bool testMode = true;

     IEnumerator Start()
    {
        Advertisement.Initialize(gameId, testMode);

        while (!Advertisement.IsReady(placementId))
            yield return null;
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_RIGHT);
        Advertisement.Banner.Show(placementId);
    }
}
