using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPanel : MonoBehaviour
{
    [SerializeField] GameObject panel = default;
    [SerializeField] GameObject wallParent;

    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;

    [SerializeField] GameObject backArrow;

    public bool isShow = false;

    // int selectCount = ItemBox.instance.selectCount;

    public int selectCount = 0;

    Item beforeItem;

    // アイテムを選択かつアイテムが2回押されたら
    // 拡大表示
    public void OpenPanel()
    {
        Item currentItem = ItemBox.instance.GetSelectedItem();
        if (selectCount == 0 && !isShow)
        {
            selectCount = 1;
            beforeItem = currentItem;
            return;
        }
        if (currentItem == beforeItem && selectCount == 1 && !isShow)
        {
            isShow = true;
            selectCount = 2;
            panel.SetActive(true);
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
            backArrow.SetActive(true);
            beforeItem = currentItem;
        }
        beforeItem = currentItem;
    }

    // 戻るボタンorアイテムが押されたら
    // 拡大表示を閉じる
    public void ClosePanel()
    {
        Item currentItem = ItemBox.instance.GetSelectedItem();
        if (selectCount == 2 && isShow)
        {
            isShow = false;
            selectCount = 1;
            panel.SetActive(false);

            // フォーカスしてる状態で拡大表示->削除するときは、左右ボタンいらない
            if (wallParent.GetComponent<Transform>().localPosition.y == 0)
            {
                rightArrow.SetActive(true);
                leftArrow.SetActive(true);
            }
            backArrow.SetActive(false);
        }
    }
}
