using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData", order = 1)]

public class GameData : ScriptableObject
{
    [SerializeField] private int _money;
    public int Money
    {
        get { return _money; }
        set
        {
            if (value <= 0)
            {
                _money = 0;
            }
            else
                _money = value;
        }
    }

    private int _standartTurretCost;
    public int StandartTurretCost
    {
        get { return _standartTurretCost; }
        private set { _standartTurretCost = value; }
    }

    private int _missileLauncherCost;
    public int MissileLauncherCost
    {
        get { return _missileLauncherCost; }
        private set { _missileLauncherCost = value; }
    }


    private int _laserBeamerCost;
    public int LaserBeamerCost
    {
        get { return _laserBeamerCost; }
        private set { _laserBeamerCost = value; }
    }

    public GameData()
    {
        StandartTurretCost = 100;
        MissileLauncherCost = 250;
        LaserBeamerCost = 350;
    }

}
