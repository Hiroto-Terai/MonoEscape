using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
  // スロット自体のImageコンポーネント
  Image image;

  private void Awake()
  {
    image = GetComponent<Image>();
  }

  // アイテムを受け取ったら画像をスロットに表示する

  public void SetItem(Item item)
  {
    UpdateImage(item);
  }

  void UpdateImage(Item item)
  {
    // スロットのImageコンポーネントにPickupObjの画像を入れる
    image.sprite = item.sprite;
  }
}
