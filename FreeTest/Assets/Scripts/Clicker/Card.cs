using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.EventSystems;

public class Card: MonoBehaviour, IPointerClickHandler,  IPointerDownHandler
{
    public CardData data;
    public static event Action<Card, PointerEventData> OnClicked;


    public void OnPointerClick(PointerEventData eventData)
    {
        OnClicked?.Invoke(this, eventData); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // OnTargetClicked?.Invoke(this, eventData); 
    }

}