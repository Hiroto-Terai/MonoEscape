using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] Slot[] slots;
    [SerializeField] Slot selectedSlot = null;

    // アイテム使用後のitemを持つslotの数をカウントするための変数
    public int slotsCount = 0;

    // どこでも実行できるようにstatic化
    public static ItemBox instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // slots配列にslot要素をコードから挿入
            slots = GetComponentsInChildren<Slot>();
        }
    }

    // PickupObjがタップされたら、アイテムBOXに格納
    public void SetItem(Item item)
    {
        foreach (Slot slot in slots)
        {
            // Slotsを1つずつ見て、空いてたら画像(itemも)を入れる
            if (slot.IsEmpty())
            {
                slot.SetItem(item);
                break;
            }
        }
    }

    // アイテムBOX内にあるアイテムをタップした時にアイテム周辺に枠ができる
    public void OnSelectSlot(int position)
    {
        // 一旦全てのスロットの選択フレームを非表示
        foreach (Slot slot in slots)
        {
            slot.HideFrame();
        }
        // 選択されたスロットの選択フレームを表示
        if (slots[position].OnSelected())
        {
            selectedSlot = slots[position];
        }
    }

    // アイテムの使用/使えるなら使う
    public bool TryUseItem(Item.Type type)
    {
        // 選択スロットがあるかどうか
        if (selectedSlot == null)
        {
            return false;
        }
        // Hammerを選択しているか
        if (selectedSlot.GetItem().type != type)
        {
            return false;
        }
        selectedSlot.SetItem(null);

        return true;

        // itemが入っているslotの数を確認
        // foreach (Slot slot in slots)
        // {
        //   if (slot.GetItem() != null)
        //   {
        //     slotsCount++;
        //   }
        // }

        // アイテム使用後に、itemを持っているslotが1つ以上でもあれば実行
        // 使用したスロット以降の要素を使用したスロット(選択したスロットselectedSlot)を開始位置として最後の要素までCopyする
        // 4つアイテムを持ってて、1つ目を使った場合、後ろ3つの要素が左に一つずれる
        // 4つアイテムを持ってて、2つ目を使った場合、後ろ2つの要素が左に一つずれる
        // ずらす要素数は 配列の長さ-(使用したスロット位置+1) でできそう

        // if (slotsCount >= 1)
        // {
        //   Array.Copy(slots, Array.IndexOf(slots, selectedSlot) + 1, slots, Array.IndexOf(slots, selectedSlot), slots.Length - (Array.IndexOf(slots, selectedSlot) + 1));

        //   // slots[i]からスロットのImageコンポーネントを取得する必要がある

        //   for (int i = 0; i < slotsCount; i++)
        //   {
        //     // slotのimageにitemのimageを入れる
        //     slots[i].image.sprite = slots[i].GetItem().sprite;
        //     Debug.Log(slots[i].GetItem().sprite);
        //     Debug.Log(slots[i].GetItem().type);
        //   }
        // }

        // 全てのアイテムBOX画像を削除

        // // 子オブジェクトを返却する配列作成
        // var children = new Transform[parent.childCount];
        // var childIndex = 0;

        // // 子オブジェクトを順番に配列に格納
        // foreach (Transform child in parent)
        // {
        //   children[childIndex++] = child;
        // }

        // for (int i = 0; i < slots.Length; i++)
        // {
        //   Sprite[] slotsSprites = itemBox.GetComponentInChildren<Sprite[]>();
        //   slotsSprites[i] = null;
        // }

        // Itemに設定されている画像を表示
    }

    // ZoomPanelスクリプトのShowPanel関数で実行
    public Item GetSelectedItem()
    {
        if (selectedSlot == null)
        {
            return null;
        }
        return selectedSlot.GetItem();
    }
}
