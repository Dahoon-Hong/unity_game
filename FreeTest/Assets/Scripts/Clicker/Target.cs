using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;



public class Target : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{

    public static event Action<Target, PointerEventData> OnTargetClicked;

    public Sprite[] sprites;
    public float changeInterval = 1.0f;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;

    private void Awake()
    {
        Debug.Log("Awake");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (sprites != null && sprites.Length > 0)
        {
            StartCoroutine(ChangeSpriteRoutine());
        }
    }

    private IEnumerator ChangeSpriteRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            if (sprites.Length > 0)
            {
                currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
                spriteRenderer.sprite = sprites[currentSpriteIndex];
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        OnTargetClicked?.Invoke(this, eventData); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        OnTargetClicked?.Invoke(this, eventData); 
    }


    public void OnHit()
    {
        Debug.Log("hit");

    }
}
