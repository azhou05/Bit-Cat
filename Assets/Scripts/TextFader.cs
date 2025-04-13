using UnityEngine;
using TMPro;

public class TextFader : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float fadeDuration = 1f;

    private void Awake()
    {
        Color c = textMesh.color;
        c.a = 0f;
        textMesh.color = c;
    }

    public void FadeIn()
    {
        StopAllCoroutines();
        StartCoroutine(FadeText(1f));
    }

    public void FadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(FadeText(0f));
    }

    private System.Collections.IEnumerator FadeText(float targetAlpha)
    {
        float startAlpha = textMesh.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            Color c = textMesh.color;
            c.a = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            textMesh.color = c;
            time += Time.deltaTime;
            yield return null;
        }

        Color final = textMesh.color;
        final.a = targetAlpha;
        textMesh.color = final;
    }
}
