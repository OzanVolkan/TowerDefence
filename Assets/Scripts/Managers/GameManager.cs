using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonManager<GameManager>
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameWonScreen;

    [SerializeField] List<GameObject> _currentEnemies;
    public List<GameObject> CurrentEnemies
    {
        get { return _currentEnemies; }
        set { _currentEnemies = value; }
    }


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

    private int _levelRound;
    public int LevelRound
    {
        get { return _levelRound; }
        set { _levelRound = value; }
    }

    private bool _isGameOver;
    public bool IsGameOver
    {
        get { return _isGameOver; }
        set { _isGameOver = value; }
    }

    private void Start()
    {
        Lives = 13 - DataManager.Instance.gameData.Level; // Gamedata'dan current level arrayi þeklinde çek
        IsGameOver = false;
        Rounds = 0;
        LevelRound = DataManager.Instance.gameData.Level + 4; // Gamedata'dan current level arrayi þeklinde çek
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
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

    public void Pause()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    public void Win(int _waveIndex)
    {
        if (CurrentEnemies.Count == 0 && LevelRound == _waveIndex)
        {
            gameWonScreen.SetActive(true);
        }
    }

}
