using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewItemData",menuName ="ScriptableObjects/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;

    public Sprite itemImage;

    public int itemPrice;

    public bool isSelected;

    public bool isBought;
}
