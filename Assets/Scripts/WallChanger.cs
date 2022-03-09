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
    Wall0_4,
    Wall0_5,
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

  public void OnSwitchBox()
  {
    Show(Wall.Wall0_0);
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
        // フォーカスの画像
    }
  }
}
