using System;
using UnityEngine;

// Unity上で種類と画像を変更できるようにSerializableを追加
// MonoBehaviourはUnityのヒエラルキー上のオブジェクトには必要だが、Itemはデータなので不要
[Serializable]
public class Item
{
    public enum Type
    {
        Reversi,
        HintCard1,
        Hammer,
    }

    public Type type;               // 種類
    public Sprite sprite;           // Slotに表示する画像
    public Sprite zoomImage;    // 拡大表示する画像   

    // 型
    public Item(Type type, Sprite sprite, Sprite zoomImage)
    {
        this.type = type;
        this.sprite = sprite;
        this.zoomImage = zoomImage;
    }
}
