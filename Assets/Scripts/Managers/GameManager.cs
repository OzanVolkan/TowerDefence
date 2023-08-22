using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    [SerializeField] int livesAmount = 20;
    [SerializeField] GameObject gameOverScreen;

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

    private int _rounds;

    public int Rounds
    {
        get { return _rounds; }
        set { _rounds = value; }
    }


    private bool _isGameOver;
    public bool IsGameOver
    {
        get { return _isGameOver; }
        set { _isGameOver = value; }
    }


    private void Start()
    {
        Lives = livesAmount;
        IsGameOver = false;
        Rounds = 0;
    }

    public void GetDamage()
    {
        if (IsGameOver)
            return;

        Lives -= 1;

        if (Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        IsGameOver = true;
        gameOverScreen.SetActive(true);
    }

}
