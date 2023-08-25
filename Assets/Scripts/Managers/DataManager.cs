using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DataManager : SingletonManager<DataManager>
{
    public GameData gameData;

    private void Awake()
    {
        OnLoadData();
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnSaveData, new Action(OnSaveData));
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnSaveData, new Action(OnSaveData));
    }
    void OnSaveData()
    {
        _ = SaveManager.SaveData(gameData);
    }

    void OnLoadData()
    {
        _ = SaveManager.LoadData(gameData);
    }
}
