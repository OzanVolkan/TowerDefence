using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public void PuchaseStandartTurret()
    {
        BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.StandartTurret);
    }
    public void PuchaseMissileLauncher()
    {
        BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.MissileLauncher);
    }
    public void PuchaseLaserBeamer()
    {
        BuildManager.Instance.SetTurretToBuild(BuildManager.Instance.LaserBeamer);
    }
}
