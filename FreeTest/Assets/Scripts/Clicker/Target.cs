using UnityEngine;
using System;
using UnityEngine.EventSystems;



public class Target : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{

    public static event Action<Target> OnTargetClicked;
    private void Awake()
    {
        Debug.Log("Awake");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        OnTargetClicked?.Invoke(this); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        OnTargetClicked?.Invoke(this); 
    }


    public void OnHit()
    {
        Debug.Log("hit");

    }
}
