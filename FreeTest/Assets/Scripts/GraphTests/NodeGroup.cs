using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public enum NodeType
{
    Source,
    Target
}

public class NodeGroup : MonoBehaviour, IPointerClickHandler
{
    public NodeType type;
    public List<NodeGroup> edges = new List<NodeGroup>();

    public static event Action<NodeGroup> OnNodeGroupClicked;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked");
        OnNodeGroupClicked?.Invoke(this); 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("down");
        // OnNodeGroupClicked?.Invoke(this); 
    }

    public void SetSelected(bool isSelected)
    {
        if (spriteRenderer == null) return;

        spriteRenderer.color = isSelected ? Color.yellow : originalColor;
    }
}
