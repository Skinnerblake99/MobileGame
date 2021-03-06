﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    //Code sourced from https://www.youtube.com/watch?v=beuoNuK2tbk&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0 8/10/2020
    public Color Highlighting;

    public Vector3 positionOffset;

    private Renderer rend;

    public GameObject turret;

    private Color StartingColor;
    //Might not be required
    //public float TouchCoolDown = 2.0f;

    PlayerMoney playerMoney;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartingColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if (turret != null)
        {
            Debug.Log("Space Occupied");
            return;
        }
        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {

        if (!buildManager.CanBuild)
            return;

        rend.material.color = Highlighting;
    }

    

    void OnMouseExit()
    {
        rend.material.color = StartingColor;
    }

    
}
