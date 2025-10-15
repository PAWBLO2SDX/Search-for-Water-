using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item1 : ScriptableObject
{

    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("both")]
    public Sprite image;

}

public enum ItemType
{
    BuildingBlock,
    tool
}

public enum ActionType
{
    Dig,
    Mine
}
