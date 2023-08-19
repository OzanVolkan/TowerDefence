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


    private TurretBluePrint _turretToBuild;
    public TurretBluePrint TurretToBuild
    {
        get { return _turretToBuild; }
        set { _turretToBuild = value; }
    }

    public bool CanBuild { get { return TurretToBuild != null; } }

    public void BuildTurretOn(Node node, Vector3 position)
    {
        GameObject turret = Instantiate(TurretToBuild.Prefab, position, Quaternion.identity);
        node.CurrentTurret = turret;
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        TurretToBuild = turret;
    }


}
