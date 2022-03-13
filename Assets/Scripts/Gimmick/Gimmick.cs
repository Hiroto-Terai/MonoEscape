using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Item.Type clearItemType;
    [SerializeField] GameObject Crashed;

    // クリックした時
    // ハンマーを持っていて選択していたら
    // 削除(非表示)

    // クリック判定
    // アイテム所持判定

    public void OnClickObj()
    {
        // アイテムHammerを持っているかどうか
        bool clear = ItemBox.instance.TryUseItem(clearItemType);
        if (clear)
        {
            // 壊れる前の壁を削除
            gameObject.SetActive(false);
            Crashed.SetActive(true);
        }
    }
}
