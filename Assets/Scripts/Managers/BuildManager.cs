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

    [Header("Particle")]
    [SerializeField] GameObject buildEffect;

    public bool CanBuild { get { return TurretToBuild != null; } }
    public bool HasMoney { get { return DataManager.Instance.gameData.Money >= TurretToBuild.Cost; } }

    public void BuildTurretOn(Node node, Vector3 position)
    {
        if (DataManager.Instance.gameData.Money < TurretToBuild.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        DataManager.Instance.gameData.Money -= TurretToBuild.Cost;

        GameObject turret = Instantiate(TurretToBuild.Prefab, position, Quaternion.identity);
        node.CurrentTurret = turret;

        GameObject effect = Instantiate(buildEffect, position, Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left: " + DataManager.Instance.gameData.Money);
    }

    public void SelectTurretToBuild(TurretBluePrint turret, int _cost)
    {
        TurretToBuild = turret;
        turret.Cost = _cost;
    }


}
