using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // スロット自体のImageコンポーネント
    public Image image;
    Item item;

    public static Slot instance;

    [SerializeField] GameObject ChoiceFrame;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        image = GetComponent<Image>();
        image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    private void Start()
    {
        ChoiceFrame.SetActive(false);
    }

    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    // アイテムを受け取ったら画像をスロットに表示する

    public void SetItem(Item item)
    {
        this.item = item;
        UpdateImage(item);
    }

    public Item GetItem()
    {
        return item;
    }

    public void UpdateImage(Item item)
    {
        // スロットのImageコンポーネントにPickupObjの画像を入れる
        if (item == null)
        {
            image.sprite = null;
            image.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            HideFrame();
        }
        else
        {
            image.sprite = item.sprite;
            image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }

    public bool OnSelected()
    {
        if (item == null)
        {
            return false;
        }
        ChoiceFrame.SetActive(true);
        return true;
    }

    public void HideFrame()
    {
        ChoiceFrame.SetActive(false);
    }
}
