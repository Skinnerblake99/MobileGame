using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHiding : MonoBehaviour
{
    //In charge of cleaning up gamne AI
    GameObject Panel;
    GameObject closeButton;
    public GameObject cameraMain;
    public GameObject cameraOut;
    public GameObject cameraMainBtnOff;
    public GameObject cameraMainBtnOn;
    void Start()
    {
        Panel = GameObject.FindGameObjectWithTag("Panel");
        Panel.SetActive(false);
        closeButton = GameObject.FindGameObjectWithTag("closeButton");
        closeButton.SetActive(false);
        cameraOut = GameObject.FindGameObjectWithTag("OverviewCam");
        cameraOut.SetActive(false);
        cameraMain = GameObject.FindGameObjectWithTag("MainCam");
        cameraMainBtnOff = GameObject.FindGameObjectWithTag("CameraButtonOff");
        cameraMainBtnOn = GameObject.FindGameObjectWithTag("CameraButtonOn");
        cameraMainBtnOn.SetActive(false);
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

    public void CameraMainOn()
    {
        cameraMain.SetActive(true);
        cameraOut.SetActive(false);
        cameraMainBtnOn.SetActive(false);
        cameraMainBtnOff.SetActive(true);
    }

    public void CameraMainOff()
    {
        cameraOut.SetActive(true);
        cameraMain.SetActive(false);
        cameraMainBtnOff.SetActive(false);
        cameraMainBtnOn.SetActive(true);
    }
}
