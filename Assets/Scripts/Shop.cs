using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TurretBluePrint BasicTurret;
    public TurretBluePrint MoneyTurret;
    public TurretBluePrint SlowTurret;
     void Start()
    {
        buildManager = BuildManager.instance;  
    }

    public void SelectBasicTurret()
    {
        Debug.Log("Basic turret purchased");
        buildManager.SelectTurretToBuild(BasicTurret);
    }
    public void SelectMoneyTurret()
    {
        Debug.Log("Basic turret purchased");
        buildManager.SelectTurretToBuild(MoneyTurret);
    }
    public void SelectSlowTurret()
    {
        Debug.Log("Basic turret purchased");
        buildManager.SelectTurretToBuild(SlowTurret);
    }

}
