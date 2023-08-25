using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        EventManager.Broadcast(GameEvent.OnFadeOut, SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
