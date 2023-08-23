using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
    [Header("Basic")]

    [SerializeField] GameObject _prefab;
    public GameObject Prefab
    {
        get { return _prefab; }
        set { _prefab = value; }
    }

    [SerializeField] int _cost;
    public int Cost
    {
        get { return _cost; }
        set { _cost = value; }
    }

    [Header("Upgrade")]

    [SerializeField] GameObject _upgradedPrefab;
    public GameObject UpgradedPrefab
    {
        get { return _upgradedPrefab; }
        set { _upgradedPrefab = value; }
    }

    [SerializeField] int _upgradeCost;

    public int UpgradeCost
    {
        get { return _upgradeCost; }
        set { _upgradeCost = value; }
    }

    public int GetSellAmount()
    {
        return Cost / 2;
    }
}
