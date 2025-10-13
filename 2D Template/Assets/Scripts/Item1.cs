using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using System;

public class Item : ScriptableObject
{

    [Header("Only gmeplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    internal Sprite image;
}
