using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AnimationCurve curve;
    [SerializeField] Image img;
    public void Play()
    {
        StartCoroutine(FadeOut(2));
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

    IEnumerator FadeOut(int _scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }

        SceneManager.LoadScene(_scene);
    }
}
