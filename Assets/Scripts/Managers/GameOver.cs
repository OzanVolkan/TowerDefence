using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        roundsText.text = GameManager.Instance.Rounds.ToString();
    }

    #region Buttons
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    #endregion
}
