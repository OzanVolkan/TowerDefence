using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesCounter;

    void Update()
    {
        livesCounter.text = GameManager.Instance.Lives.ToString() + " LIVES";
    }
}
