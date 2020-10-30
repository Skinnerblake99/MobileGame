using UnityEngine;

public class Shop : MonoBehaviour
{
    //Sourced from https://www.youtube.com/watch?v=beuoNuK2tbk&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0 8/10/2020
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
