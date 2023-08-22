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

    private Node _selectedNode;
    public  Node SelectedNode
    {
        get { return _selectedNode; }
        set { _selectedNode = value; }
    }

    private TurretBluePrint _turretToBuild;
    public TurretBluePrint TurretToBuild
    {
        get { return _turretToBuild; }
        set { _turretToBuild = value; }
    }

    [SerializeField] NodeUI nodeUI;

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

        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (SelectedNode == node)
        {
            DeselectNode();
            return;
        }

        SelectedNode = node;
        TurretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        SelectedNode = null;
        nodeUI.Hide();
    }
}
