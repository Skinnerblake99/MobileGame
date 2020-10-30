using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Code sourced from here https://www.youtube.com/watch?v=beuoNuK2tbk&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0

    public static BuildManager instance;
    private TurretBluePrint turretToBuild;
 
 
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one build manager exists blake you idiot");
            return;
        }
        instance = this;
    }
    
    public void BuildTurretOn(TowerTile node)
    {
        if (PlayerMoney.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money");
            return;
        }
        PlayerMoney.Money -= turretToBuild.cost;
        Debug.Log("Im building now");
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, node.transform.rotation);
        node.turret = turret;
    }

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
