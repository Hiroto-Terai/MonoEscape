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
    }
  }

  // PickupObjがタップされたら、アイテムBOXに格納
  public void SetItem(Item item)
  {
    slots[0].SetItem(item);
  }

  // アイテムBOX内にあるアイテムをタップした時にアイテム周辺に枠ができる
  // 選択しているフラグを立てる
  // フラグが立っている状態で何かアクションをすると動作する
}
