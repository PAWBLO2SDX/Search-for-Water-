using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System.ComponentModel;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]

    public TileBase tile;
  //public ItemType type;
  //public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    
}
