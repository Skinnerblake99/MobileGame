using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveGTower : MonoBehaviour
{
    EZMobileBasics ez;
    // Start is called before the first frame update
    void Start()
    {
        ez = FindObjectOfType<EZMobileBasics>();
        ez.UnlockAchievement5GBrainFried();
    }

}
