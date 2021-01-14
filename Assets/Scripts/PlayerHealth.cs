using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public static int Health = 3;
    public  Text TextHealth;
    public int scene;
    WhichScene ws;
    EZMobileBasics ez;
    void Start()
    {
        TextHealth = GetComponent<Text>();
        ws = FindObjectOfType<WhichScene>();
        ez = FindObjectOfType<EZMobileBasics>();
    }

    void Update()
    {
        scene = ws.Scene;
        TextHealth.text = "Media Bribes left: " + Health.ToString();
        if(Health <= 0 && scene == 2)
        {
            ez.SubmitScoreLevel1();
            SceneManager.LoadScene(3);
            //EndGame();
        }
        if (Health <= 0 && scene == 3)
        {
            ez.SubmitScoreLevel2();
            SceneManager.LoadScene(3);
            //EndGame();
        }
    }

    //Not needed here anymore
    //void EndGame()
    //{
    //    Application.Quit();
    //}
}
