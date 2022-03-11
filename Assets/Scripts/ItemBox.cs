using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
  [SerializeField] Slot[] slots;
  // どこでも実行できるようにstatic化
  public static ItemBox instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
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
    slots[position].OnSelected();
  }

  // 選択しているフラグを立てる
  // フラグが立っている状態で何かアクションをすると動作する
}
