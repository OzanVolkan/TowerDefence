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

    [SerializeField] private int _level;
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    private int _currentLevel;

    public int CurrentLevel
    {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }

}
