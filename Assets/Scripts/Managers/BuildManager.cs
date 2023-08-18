using UnityEngine;
using System;
public class BuildManager : SingletonManager<BuildManager>
{
    [SerializeField] GameObject _standartTurret;
    public GameObject StandartTurret { get { return _standartTurret; } }

    [SerializeField] GameObject _missileLauncher;
    public GameObject MissileLauncher { get { return _missileLauncher; } }

    [SerializeField] GameObject _laserBeamer;
    public GameObject LaserBeamer { get { return _laserBeamer; } }


    private GameObject _turretToBuild;
    public GameObject TurretToBuild
    {
        get { return _turretToBuild; }
        set { _turretToBuild = value; }
    }


    public GameObject GetTurretToBuild()
    {
        return TurretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        TurretToBuild = turret;
    }


}
