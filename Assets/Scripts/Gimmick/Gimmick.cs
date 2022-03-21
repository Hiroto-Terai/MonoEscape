using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Item.Type clearItemType = default;
    [SerializeField] GameObject crashedWall = null;
    Transform TransForm;

    // ゴミ箱
    private bool isUpTrashCan = false;

    // カフェラテ
    private bool isUpCaffelate = false;

    // 金庫
    [SerializeField] GameObject[] blackPanels = null;
    [SerializeField] GameObject safeOpened = null;
    GameObject blackMass;
    bool isClick;

    // レバーBOX
    [SerializeField] GameObject[] reversies = null;
    [SerializeField] GameObject switchBoxOpened = null;
    GameObject reversi;

    private void Start()
    {
        TransForm = GetComponent<Transform>();
    }

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
    public void SafeMassChangeBlack()
    {
        // 押すと子オブジェクトの黒マス表示
        blackMass = transform.GetChild(0).gameObject;
        blackMass.SetActive(true);
    }

    public void SafeMassChangeWhite()
    {
        // 黒マスを押すと非表示
        this.gameObject.SetActive(false);
    }

    public void OnClickSafeEnter()
    {
        // 黒->白->黒->黒の順(後で修正?)にすると前の画面で金庫のOpenedが表示される
        if (blackPanels[0].activeSelf && !blackPanels[1].activeSelf
        && blackPanels[2].activeSelf && blackPanels[3].activeSelf)
        {
            safeOpened.SetActive(true);
        }
    }

    // レバーBOXギミック
    // リバーシを選択した状態で型を押すとはまる
    // アイテムBOXのリバーシが消える
    // 3つはまると前の画面で金庫のOpenedが表示される
    public void OnLeverBoxSwitch()
    {
        bool isOkUseReversi = ItemBox.instance.TryUseItem(clearItemType);
        if (isOkUseReversi)
        {
            reversi = transform.GetChild(0).gameObject;
            reversi.SetActive(true);
        }
    }

    public void OnLeber()
    {
        if (reversies[0].activeSelf && reversies[1].activeSelf
        && reversies[2].activeSelf)
        {
            switchBoxOpened.SetActive(true);
        }
    }

    // 壁壊すギミック
    // ハンマーを選択した状態で壁を押すと壊れる
    // ハンマーは消えない
    public void OnClickWall()
    {
        // アイテムHammerを持っているかどうか
        bool isOkUseHammer = ItemBox.instance.TryUseItem(clearItemType);
        if (isOkUseHammer)
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
