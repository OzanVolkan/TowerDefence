using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    private int livesAmount = 20;

    private int _lives;
    public int Lives
    {
        get { return _lives; }
        set
        {
            if (value <= 0)
            {
                _lives = 0;
            }
            else
            {
                _lives = value;
            }
        }
    }

    private void Start()
    {
        Lives = livesAmount;
    }

    public void GetDamage()
    {
        Lives -= 1;

        if (Lives <= 0)
        {
            Debug.Log("Fail!");
        }
    }

}
