using System.Collections;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifetime = 1f;
    public float fadeDuration = 0.5f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Debug.Log("EffectObject 시작");
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOutAndDestroy());
    }

    private IEnumerator FadeOutAndDestroy()
    {
        // Wait for the initial part of the lifetime
        yield return new WaitForSeconds(lifetime - fadeDuration);

        // Fade out
        float timer = 0;
        Color startColor = spriteRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, endColor, timer / fadeDuration);
            yield return null;
        }

        // Destroy the object
        Destroy(gameObject);
    }
}
