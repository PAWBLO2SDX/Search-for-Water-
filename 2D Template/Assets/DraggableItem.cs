using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAftherDrag;

    public void OnBeginDrag(PointerEventData eventData) { 
        Debug.Log("Begin drag");
        parentAftherDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData) { 
        Debug.Log("Dragging");
        transform.position = Input.mousePosition; 
    }

    public void OnEndDrag(PointerEventData eventData) { 
        Debug.Log("End drag");
        transform.SetParent(parentAftherDrag);
        image.raycastTarget = true;
    }
}
