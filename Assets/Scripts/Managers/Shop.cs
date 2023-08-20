using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] TurretBluePrint standartTurret;
    [SerializeField] TurretBluePrint missileLauncher;
    [SerializeField] TurretBluePrint laserBeamer;
    public void PuchaseStandartTurret()
    {
        BuildManager.Instance.SelectTurretToBuild(standartTurret,DataManager.Instance.gameData.StandartTurretCost);
    }
    public void PuchaseMissileLauncher()
    {
        BuildManager.Instance.SelectTurretToBuild(missileLauncher, DataManager.Instance.gameData.MissileLauncherCost);
    }
    public void PuchaseLaserBeamer()
    {
        BuildManager.Instance.SelectTurretToBuild(laserBeamer, DataManager.Instance.gameData.LaserBeamerCost);
    }
}
