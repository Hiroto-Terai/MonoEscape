using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomPanel : MonoBehaviour
{
    [SerializeField] GameObject panel = default;
    [SerializeField] GameObject wallParent;
    [SerializeField] GameObject zoomImageObj;
    public Image zoomImage;

    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;

    [SerializeField] GameObject backArrow;

    public bool isShow = false;

    public int selectCount = 0;

    Item beforeItem;
    public Sprite hintCard2;

    private void Start()
    {
        zoomImage = zoomImageObj.GetComponent<Image>();
    }

    // アイテムを選択かつアイテムが2回押されたら
    // 拡大表示
    public void OpenPanel()
    {
        Item currentItem = ItemBox.instance.GetSelectedItem();
        if (selectCount == 0 && !isShow)
        {
            selectCount = 1;
        }
        // 今選んだアイテムが左メモ、前に選んだアイテムが右メモの時
        // 今選んだアイテムが右メモ、前に選んだアイテムが左メモの時
        if (beforeItem != null)
        {
            if ((currentItem.type == Item.Type.Memo_left && beforeItem.type == Item.Type.Memo_right)
                    || (currentItem.type == Item.Type.Memo_right && beforeItem.type == Item.Type.Memo_left))
            {
                // 右メモ(左メモ)をアイテムBOXから削除
                // 右メモ(左メモ)をItemデータベースから削除
                ItemBox.instance.DeleteItem(beforeItem);
                Debug.Log(currentItem);
                ItemBox.instance.DeleteItem(currentItem);
                Debug.Log("current");
                // Itemデータベースで左メモ(右メモ)を合体メモに変更
                currentItem.type = Item.Type.HintCard2;
                currentItem.sprite = hintCard2;
                currentItem.zoomImage = hintCard2;

                // アイテムBOXの左メモ(右メモ)を合体メモに変更
                // 合体メモを拡大表示
                ItemBox.instance.SetItem(currentItem);
            }
        }
        if (currentItem == beforeItem && selectCount == 1 && !isShow)
        {
            isShow = true;
            selectCount = 2;
            panel.SetActive(true);
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
            backArrow.SetActive(true);
        }
        zoomImage.sprite = ItemGenerator.instance.GetZoomImage(currentItem.type);
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
