using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Inventoryslot2 : MonoBehaviour, IDropHandler
{
   void IDropHandler.OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAftherDrag = transform;
        }
   } 

}
