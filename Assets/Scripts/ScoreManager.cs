using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static int Score;
    // public string ScoreString;
    public  Text TextScore;
    public float scoreCounter;
    int convertedCounter;
    bool save = false;
    bool hasSaved = false;
    void Start()
    {
        TextScore = GetComponent<Text>();
        save = false;
        hasSaved = false;
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreString = Score.ToString();
        TextScore.text ="Score: " +  Score.ToString();
        scoreCounter += Time.deltaTime;
        if (save && !hasSaved)
        {
            convertedCounter = Mathf.RoundToInt(scoreCounter);
            Score += convertedCounter;
            hasSaved = true;
        }
    }
}
