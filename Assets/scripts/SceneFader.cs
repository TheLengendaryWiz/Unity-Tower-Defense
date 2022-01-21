using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve animationCurve;
    public void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t-=Time.deltaTime;
            float a = animationCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1)
        {
            t+=Time.deltaTime;
            float a = animationCurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
    public void Button()
    {
        FadeTo("Main Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}