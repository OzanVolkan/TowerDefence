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
    [SerializeField] GameObject _buildEffect;
    public GameObject BuildEffect
    {
        get { return _buildEffect; }
        set { _buildEffect = value; }
    }

    [SerializeField] GameObject _sellEffect;
    public GameObject SellEffect
    {
        get { return _sellEffect; }
        set { _sellEffect = value; }
    }

    public bool CanBuild { get { return TurretToBuild != null; } }
    public bool HasMoney { get { return DataManager.Instance.gameData.Money >= TurretToBuild.Cost; } }


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

    public TurretBluePrint GetTurretToBuild()
    {
        return TurretToBuild;
    }
}
