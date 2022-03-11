using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
  // スロット自体のImageコンポーネント
  Image image;
  Item item;

  [SerializeField] GameObject ChoiceFrame;
  private void Awake()
  {
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

  void UpdateImage(Item item)
  {
    // スロットのImageコンポーネントにPickupObjの画像を入れる
    image.sprite = item.sprite;
    image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
  }

  public void OnSelected()
  {
    if (item == null)
    {
      return;
    }
    ChoiceFrame.SetActive(true);
  }

  public void HideFrame()
  {
    ChoiceFrame.SetActive(false);
  }
}
