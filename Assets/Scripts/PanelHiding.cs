using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHiding : MonoBehaviour
{
    //In charge of cleaning up gamne AI
    GameObject Panel;
    GameObject closeButton;
    void Start()
    {
        Panel = GameObject.FindGameObjectWithTag("Panel");
        Panel.SetActive(false);
        closeButton = GameObject.FindGameObjectWithTag("closeButton");
        closeButton.SetActive(false);
    }

    public void ShopOpen()
    {
        Panel.SetActive(true);
    }

    public void ShopClose()
    {
        Panel.SetActive(false);
        closeButton.SetActive(false);
    }

    public void ActivateClose()
    {
        closeButton.SetActive(true);
    }

}
