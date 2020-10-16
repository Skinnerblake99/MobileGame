using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int Health = 3;
    public  Text TextHealth;
    void Start()
    {
        TextHealth = GetComponent<Text>();

    }

    void Update()
    {
        TextHealth.text = "Media Bribes left: " + Health.ToString();
        if(Health <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Application.Quit();
    }
}
