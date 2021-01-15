using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    BannerAds bannerAds;
    public void StartGame()
    {
        bannerAds = FindObjectOfType<BannerAds>();
        SceneManager.LoadScene(1);
        bannerAds.testMode = false;
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene(0);
    }

    public void Options()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
