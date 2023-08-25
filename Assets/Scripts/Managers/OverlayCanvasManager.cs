using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class OverlayCanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roundsText;
    [SerializeField] TextMeshProUGUI winRoundsText;

    private void Update()
    {
        if(roundsText.gameObject.activeSelf)
        roundsText.text = GameManager.Instance.Rounds.ToString();
        
        if(winRoundsText.gameObject.activeSelf)
            winRoundsText.text = GameManager.Instance.LevelRound.ToString();

    }

    #region Buttons
    public void Retry()
    {
        Time.timeScale = 1;
        EventManager.Broadcast(GameEvent.OnSaveData);
        EventManager.Broadcast(GameEvent.OnFadeOut, SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        EventManager.Broadcast(GameEvent.OnSaveData);
        EventManager.Broadcast(GameEvent.OnFadeOut, 1);
    }

    public void Continue()
    {
        GameManager.Instance.Pause();
    }

    public void NextLevel()
    {
        DataManager.Instance.gameData.Level++;
        DataManager.Instance.gameData.CurrentLevel++;
        EventManager.Broadcast(GameEvent.OnSaveData);
        EventManager.Broadcast(GameEvent.OnFadeOut, SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}
