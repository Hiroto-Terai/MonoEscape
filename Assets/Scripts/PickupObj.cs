using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    [SerializeField] Item.Type itemType;
    Item item;

    private void Start()
    {
        // itemTypeに応じてitemを生成(アイテムに対してTypeとSpriteを設定する)
        item = ItemGenerator.instance.Spawn(itemType);
    }

    public void OnClickObj()
    {
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);
    }
}
