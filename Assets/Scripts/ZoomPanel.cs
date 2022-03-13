using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPanel : MonoBehaviour
{
    [SerializeField] GameObject panel = default;

    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;

    [SerializeField] GameObject backArrow;

    private bool isShow = false;

    public void ChangePanel()
    {
        Item item = ItemBox.instance.GetSelectedItem();
        if (item != null && ItemBox.instance.selectCount == 1 && !isShow)
        {
            OpenPanel();
        }
        else if (ItemBox.instance.selectCount == 2 && isShow)
        {
            ClosePanel();
        }
    }

    // アイテムを選択かつアイテムが2回押されたら
    // 拡大表示
    public void OpenPanel()
    {
        isShow = true;
        ItemBox.instance.selectCount++;
        Debug.Log(ItemBox.instance.selectCount);
        panel.SetActive(true);
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);
        backArrow.SetActive(true);
    }

    // 戻るボタンorアイテムが押されたら
    // 拡大表示を閉じる
    public void ClosePanel()
    {
        isShow = false;
        ItemBox.instance.selectCount--;
        Debug.Log(ItemBox.instance.selectCount);
        panel.SetActive(false);
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        backArrow.SetActive(false);
    }
}
