using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCountDownText;
    [SerializeField] TextMeshProUGUI moneyCounterText;
    void Start()
    {
    }

    void Update()
    {
        waveCountDownText.text = string.Format("{0:0.00}", WaveSpawner.Countdown).Replace(',', '.');
        moneyCounterText.text = "$" + DataManager.Instance.gameData.Money;
    }


}
