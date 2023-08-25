using UnityEngine;
using UnityEngine.SceneManagement;
public class First : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //EventManager.Broadcast(GameEvent.OnFadeOut, SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
