using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
public class SceneFader : MonoBehaviour
{
	[SerializeField] Image img;
	[SerializeField] AnimationCurve curve;

	void Start()
	{
		StartCoroutine(FadeIn());
	}

	public void FadeTo(int scene)
	{
		StartCoroutine(FadeOut(scene));
	}

	IEnumerator FadeIn()
	{
		float t = 1f;

		while (t > 0f)
		{
			t -= Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut(int _scene)
	{
		float t = 0f;

		while (t < 1f)
		{
			t += Time.deltaTime;
			float a = curve.Evaluate(t);
			img.color = new Color(0f, 0f, 0f, a);
			yield return 0;
		}

		SceneManager.LoadScene(_scene);
	}

	private void OnFadeOut(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }

	private void OnEnable()
    {
		EventManager.AddHandler(GameEvent.OnFadeOut, new Action<int>(OnFadeOut));
    }

    private void OnDisable()
    {
		EventManager.RemoveHandler(GameEvent.OnFadeOut, new Action<int>(OnFadeOut));
	}

}
