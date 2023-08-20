using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DataManager : SingletonManager<DataManager>
{
    public GameData gameData;
    void OnSaveData()
    {
        _ = SaveManager.SaveData(gameData);
    }

    void OnLoadData()
    {
        _ = SaveManager.LoadData(gameData);
    }
}
