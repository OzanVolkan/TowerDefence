using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelector : MonoBehaviour
{
    [SerializeField] Button[] lvlSelectButtons;

    private void Start()
    {
        for (int i = 0; i < lvlSelectButtons.Length; i++)
        {
            if (DataManager.Instance.gameData.Level >= i + 1)
            {
                lvlSelectButtons[i].transition = Selectable.Transition.Animation;
                lvlSelectButtons[i].interactable = true;
            }
            else
            {
                lvlSelectButtons[i].transition = Selectable.Transition.ColorTint;
                lvlSelectButtons[i].interactable = false;
            }

            lvlSelectButtons[i].transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();

            int index = i;
            lvlSelectButtons[i].onClick.AddListener(() => SetCurrentLevel(index));
        }
    }

    public void SelectLevel()
    {
        EventManager.Broadcast(GameEvent.OnFadeOut, SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SetCurrentLevel(int index)
    {
        DataManager.Instance.gameData.CurrentLevel = index + 1;
    }
}
