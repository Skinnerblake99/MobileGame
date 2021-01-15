using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    public GameObject btnSound;
    public float soundCountdown;
    // Start is called before the first frame update
    void Start()
    {
        btnSound = GameObject.FindGameObjectWithTag("ButtonPress");
        btnSound.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        soundCountdown += Time.deltaTime;
        if (soundCountdown >= 0.2)
        {
            btnSound.SetActive(false);
        }
    }

     public void TurnOn()
    {
        soundCountdown = 0;
        btnSound.SetActive(true);
    }

}
