using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Item.Type clearItemType;
    [SerializeField] GameObject crashedWall;
    Transform TransForm;
    private bool isUpTrashCan = false;
    private bool isUpCaffelate = false;

    private void Start()
    {
        TransForm = GetComponent<Transform>();
    }

    // ゴミ箱
    // クリックすると上に上がる
    // もう一度クリックすると元の位置に戻る
    public void OnClickTrashCan()
    {
        if (!isUpTrashCan)
        {
            TransForm.localPosition = new Vector2(111, 330);
            isUpTrashCan = true;
            return;
        }
        isUpTrashCan = false;
        TransForm.localPosition = new Vector2(111, 165);
    }

    // カフェラテ
    // クリックすると上に上がる
    // もう一度クリックすると元の位置に戻る
    public void OnClickCafelatte()
    {
        if (!isUpCaffelate)
        {
            TransForm.localPosition = new Vector2(0, 330);
            isUpCaffelate = true;
            return;
        }
        isUpCaffelate = false;
        TransForm.localPosition = new Vector2(0, 182);
    }

    // 金庫のパスワードギミック
    // マスを押すと黒いマスが表示される
    // もう一度マスを押すと黒が非表示になる
    // 黒->白->黒->黒の順(後で修正?)にすると前の画面で金庫のOpenedが表示される
    public void SafePassword()
    {

    }

    // レバーBOXギミック
    // リバーシを選択した状態で型を押すとはまる
    // アイテムBOXのリバーシが消える
    // 3つはまると前の画面で金庫のOpenedが表示される
    public void OnLeverBox()
    {

    }

    // 壁壊すギミック
    // ハンマーを選択した状態で壁を押すと壊れる
    // ハンマーは消えない
    public void OnClickWall()
    {
        // アイテムHammerを持っているかどうか
        bool clear = ItemBox.instance.TryUseItem(clearItemType);
        if (clear)
        {
            // 壊れる前の壁を削除
            gameObject.SetActive(false);
            crashedWall.SetActive(true);
        }
    }

    // スイッチBOXギミック
    // 白いボタンを長押しすると白->グレー->黒の順に色が変わっていく
    // 黒になると前の画面でスイッチBOXのOpenedが表示される
    public void OnSwitchBox()
    {

    }
}
