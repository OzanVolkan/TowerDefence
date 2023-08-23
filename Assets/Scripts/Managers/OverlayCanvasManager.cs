using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class OverlayCanvasManager : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI roundsText;

    private void Update()
    {
        if(roundsText.gameObject.activeSelf)
        roundsText.text = GameManager.Instance.Rounds.ToString();
    }

    #region Buttons
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        GameManager.Instance.Pause();
    }

    #endregion
}
