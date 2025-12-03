using System.Collections;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    public float lifetime = 1f;
    public float fadeDuration = 0.5f;
    public float initialUpwardVelocity = 5f;
    public float gravity = 9.8f;

    private SpriteRenderer spriteRenderer;
    private Vector3 velocity;

    void Start()
    {
        Debug.Log("EffectObject 시작");
        spriteRenderer = GetComponent<SpriteRenderer>();
        velocity = Vector3.up * initialUpwardVelocity;
        StartCoroutine(FadeOutAndDestroy());
    }

    void Update()
    {
        velocity.y -= gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
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
