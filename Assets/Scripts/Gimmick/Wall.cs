using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
  [SerializeField] Item.Type clearItem;
  [SerializeField] GameObject Crashed;

  // クリックした時
  // ハンマーを持っていて選択していたら
  // 削除(非表示)

  // クリック判定
  // アイテム所持判定

  public void OnClickObj()
  {
    // アイテムHammerを持っているかどうか
    bool clear = ItemBox.instance.TryUseItem(clearItem);
    if (clear)
    {
      // 壊れる前の壁を削除
      gameObject.SetActive(false);
      Crashed.SetActive(true);
    }
  }
}
