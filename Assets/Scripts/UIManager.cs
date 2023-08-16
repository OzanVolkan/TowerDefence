using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveCountDownText;
    void Start()
    {
    }

    void Update()
    {
        waveCountDownText.text = Mathf.Round(WaveSpawner.Countdown).ToString();
    }


}
