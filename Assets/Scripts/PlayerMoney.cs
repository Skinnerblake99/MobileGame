using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMoney : MonoBehaviour
{
    private  float StartMoney = 300f;
    [SerializeField]
    public static float Money;
    private  float IncomeBase = 100;
    private  float IncomeMod;
    private float AmountOfMoneyTowers;
    private float MoneyToAdd;
    public Text TextMoney;
    // Start is called before the first frame update
    void Start()
    {
        Money = StartMoney;
        InvokeRepeating("TrackMoney", 0f, 0.5f);
        TextMoney = GetComponent<Text>();
    }

    void TrackMoney()
    {
        //Tower doubles base income , money increases by a factor of n money towers
        AmountOfMoneyTowers = GameObject.FindGameObjectsWithTag("MoneyTower").Length * 100;
        IncomeMod = AmountOfMoneyTowers + IncomeBase;
        MoneyToAdd = IncomeMod * Time.deltaTime;
        Money += MoneyToAdd;
        TextMoney.text = "Income: " + Money.ToString("0");
    }
}
