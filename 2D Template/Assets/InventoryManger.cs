using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManger : MonoBehaviour
{
    public InventorySlot[] inventorySlots;

    public void AddItem(Item item) {

        // Find any empty slot
        for (int i = 0; i < InventorySlot.Length; i++) {
            InventorySlot slot = inventorySlots[i];
       
        }

    }

    void SpawNewItem(Item item, InventorySlot slot) {

    }

}