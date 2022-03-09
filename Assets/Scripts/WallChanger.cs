using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChanger : MonoBehaviour
{
  public GameObject rightArrow;
  public GameObject leftArrow;
  public GameObject backArrow;

  enum Wall
  {
    Wall0,
    Wall1,
    Wall2,
    Wall3,
    Wall0_0,
    Wall0_1,
    Wall0_2,
    Wall0_3,
    Wall1_0,
    Wall1_1,
    Wall1_2,
    Wall1_3,
    Wall1_4,
    Wall2_0,
    Wall2_1,
    Wall2_2,
    Wall2_3,
    Wall3_0,
    Wall3_1,
    Wall3_2,
  }

  Wall currentWall;

  private void Start()
  {
    Show(Wall.Wall0);
  }


  void HideArrows()
  {
    rightArrow.SetActive(false);
    leftArrow.SetActive(false);
    backArrow.SetActive(false);
  }

  public void OnRightButton()
  {
    switch (currentWall)
    {
      case Wall.Wall0:
        Show(Wall.Wall1);
        break;
      case Wall.Wall1:
        Show(Wall.Wall2);
        break;
      case Wall.Wall2:
        Show(Wall.Wall3);
        break;
      case Wall.Wall3:
        Show(Wall.Wall0);
        break;
    }
  }

  public void OnLeftButton()
  {
    switch (currentWall)
    {
      case Wall.Wall0:
        Show(Wall.Wall3);
        break;
      case Wall.Wall1:
        Show(Wall.Wall0);
        break;
      case Wall.Wall2:
        Show(Wall.Wall1);
        break;
      case Wall.Wall3:
        Show(Wall.Wall2);
        break;
    }
  }

  public void OnBackButton()
  {
    switch (currentWall)
    {
      case Wall.Wall0_0:
        Show(Wall.Wall0);
        break;
    }
  }

  // 壁0のフォーカス移動
  // スイッチBOX
  public void OnSwitchBox()
  {
    Show(Wall.Wall0_0);
  }
  // 宝箱
  public void OnTreasureBox()
  {
    Show(Wall.Wall0_1);
  }

  // 宝箱の南京錠
  public void OnPadLock()
  {
    Show(Wall.Wall0_1);
  }

  // 白ドア
  public void OnWhiteDoor()
  {
    Show(Wall.Wall0_3);
  }

  // 壁1のフォーカス移動
  // ゴミ箱
  public void OnTrashCan()
  {
    Show(Wall.Wall1_0);
  }

  // ゴミ箱の中
  public void OnInsideOfTrashCan()
  {
    Show(Wall.Wall1_1);
  }

  // レバーBOX（ハンマー）
  public void OnLeberBox()
  {
    Show(Wall.Wall1_2);
  }

  // レバーBOXのレバー
  public void OnLeber()
  {
    Show(Wall.Wall1_3);
  }

  // 棚
  public void OnShelf()
  {
    Show(Wall.Wall1_4);
  }

  // 壁2のフォーカス移動
  // カフェラテ
  public void OnCafellate()
  {
    Show(Wall.Wall2_0);
  }

  // ガラス瓶
  public void OnGrassBin()
  {
    Show(Wall.Wall2_1);
  }

  // パスワードBOX（暗証番号付きキー）
  public void OnPasswordBox()
  {
    Show(Wall.Wall2_2);
  }

  // パスワードBOXの入力画面
  public void OnInputOfPasswordBox()
  {
    Show(Wall.Wall2_3);
  }

  // 壁3のフォーカス移動
  // 金庫
  public void OnSafe()
  {
    Show(Wall.Wall3_0);
  }

  // 金庫の入力画面
  public void OnInputOfSafe()
  {
    Show(Wall.Wall3_1);
  }

  // 壁
  public void OnWall()
  {
    Show(Wall.Wall3_2);
  }

  void Show(Wall Wall)
  {
    HideArrows();
    currentWall = Wall;

    // 4つの壁
    switch (Wall)
    {
      case Wall.Wall0:
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 0);
        break;
      case Wall.Wall1:
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 0);
        break;
      case Wall.Wall2:
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 0);
        break;
      case Wall.Wall3:
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        transform.localPosition = new Vector2(-3000, 0);
        break;
      case Wall.Wall0_0:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 2000);
        break;
      case Wall.Wall0_1:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 2000);
        break;
      case Wall.Wall0_2:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 2000);
        break;
      case Wall.Wall0_3:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-3000, 2000);
        break;
      case Wall.Wall1_0:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 4000);
        break;
      case Wall.Wall1_1:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 4000);
        break;
      case Wall.Wall1_2:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 4000);
        break;
      case Wall.Wall1_3:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-3000, 4000);
        break;
      case Wall.Wall1_4:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-4000, 4000);
        break;
      case Wall.Wall2_0:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 6000);
        break;
      case Wall.Wall2_1:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 6000);
        break;
      case Wall.Wall2_2:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 6000);
        break;
      case Wall.Wall2_3:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-3000, 6000);
        break;
      case Wall.Wall3_0:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(0, 8000);
        break;
      case Wall.Wall3_1:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-1000, 8000);
        break;
      case Wall.Wall3_2:
        backArrow.SetActive(true);
        transform.localPosition = new Vector2(-2000, 8000);
        break;
    }
  }
}
