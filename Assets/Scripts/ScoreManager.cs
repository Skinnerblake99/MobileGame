using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static int Score;
    // public string ScoreString;
    public  Text TextScore;
    // Start is called before the first frame update
    void Start()
    {
        TextScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ScoreString = Score.ToString();
        TextScore.text ="Score: " +  Score.ToString();
    }
}
