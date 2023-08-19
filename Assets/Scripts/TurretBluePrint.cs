using System.Collections;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint
{
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

}
