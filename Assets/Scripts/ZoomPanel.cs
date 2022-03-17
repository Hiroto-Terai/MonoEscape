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

    // int selectCount = ItemBox.instance.selectCount;

    public int selectCount = 0;

    Item beforeItem;

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
