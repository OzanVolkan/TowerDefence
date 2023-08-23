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
        BuildManager.Instance.SelectTurretToBuild(standartTurret,standartTurret.Cost);
    }
    public void PuchaseMissileLauncher()
    {
        BuildManager.Instance.SelectTurretToBuild(missileLauncher, missileLauncher.Cost);
    }
    public void PuchaseLaserBeamer()
    {
        BuildManager.Instance.SelectTurretToBuild(laserBeamer, laserBeamer.Cost);
    }
}
