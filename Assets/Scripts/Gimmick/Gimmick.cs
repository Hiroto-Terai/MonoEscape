using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Item.Type clearItemType = default;
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

    // 壁
    [SerializeField] GameObject crashedWall = null;

    // ガラス瓶
    [SerializeField] GameObject crashedGrassBin = null;

    // パスワードBOX
    private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public Text[] alphabet_text;
    int targetOfPasswordBox;
    [SerializeField] GameObject passwordBoxOpened;

    // 暗証番号付きキー
    int targetOfNumberKey;
    public Text[] numbers;

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

    // ガラス瓶のギミック
    // ハンマーを選択した状態で瓶を押すと壊れる
    // ハンマーは消えない
    public void OnGrassBin()
    {
        bool isOkUseHammer = ItemBox.instance.TryUseItem(clearItemType);
        if (isOkUseHammer)
        {
            // 壊れる前のガラス瓶を削除
            gameObject.SetActive(false);
            crashedGrassBin.SetActive(true);
        }
    }

    // パスワードBOXギミック
    // 英語の入力機能
    // F->I->L->Mと入力されたら開く
    public void OnPasswordBox(int index)
    {
        targetOfPasswordBox = index;
        int i = alphabet.IndexOf(alphabet_text[targetOfPasswordBox].text);
        i++;
        if (i == alphabet.Length)
        {
            i = 0;
        }
        alphabet_text[targetOfPasswordBox].text = alphabet.Substring(i, 1);
    }

    public void OnPasswordBoxEnter()
    {
        if (alphabet_text[0].text == "F" &&
        alphabet_text[1].text == "I" &&
        alphabet_text[2].text == "L" &&
        alphabet_text[3].text == "M")
        {
            passwordBoxOpened.SetActive(true);
        }
    }

    // 暗証番号付きキーギミック
    // 拡大表示画面にてマスを押せる
    // 2->2->1->3と入力されたら鍵の先が出てくる
    public void OnNumberKey(int index)
    {
        // 数字変換
        targetOfNumberKey = index;
        int i = int.Parse(numbers[targetOfNumberKey].text);
        i++;
        if (i > 9)
        {
            i = 0;
        }
        numbers[targetOfNumberKey].text = i.ToString();

        // 判定
        if (numbers[0].text == "2" &&
        numbers[1].text == "2" &&
        numbers[2].text == "1" &&
        numbers[3].text == "3")
        {
            // スロットと拡大表示の画像を差し替え
            
        }
    }

    // 棚ギミック
    // 先が出ている鍵を選択した状態で押すと開く
    // 先が出ていない状態で押すと開かない(フラグ必要)

    // 鏡ギミック
    // それぞれの壁でズームした時にうつる画面が違う

    // 宝箱ギミック
    // 南京錠拡大画面にて、英語の入力機能
    // H->U->M->A->Nと入力されたら南京錠と宝箱が開く

    // 白い扉ギミック
    // 鍵を選択した状態で白い扉の鍵穴をクリックすると扉が開く(アニメーション付き)

}
