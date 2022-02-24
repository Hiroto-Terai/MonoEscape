using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelChanger : MonoBehaviour
{
  enum Panel
  {
    Panel0,
    Panel1,
    Panel2,
    Panel3,
    Panel4,
    Panel5,
    Panel6,
    Panel7,
    Panel8,
    Panel9,
  }

  Panel currentPanel;

  public void OnRightButton()
  {
    switch (currentPanel)
    {
      case Panel.Panel0:
        Show(Panel.Panel1);
        break;
      case Panel.Panel1:
        Show(Panel.Panel2);
        break;
      case Panel.Panel2:
        Show(Panel.Panel3);
        break;
      case Panel.Panel3:
        Show(Panel.Panel0);
        break;
    }
  }

  public void OnLeftButton()
  {
    Debug.Log("left");

    switch (currentPanel)
    {
      case Panel.Panel0:
        Show(Panel.Panel3);
        break;
      case Panel.Panel1:
        Show(Panel.Panel0);
        break;
      case Panel.Panel2:
        Show(Panel.Panel1);
        break;
      case Panel.Panel3:
        Show(Panel.Panel2);
        break;
    }
  }

  public void OnBackButton()
  {

  }

  void Show(Panel panel)
  {
    currentPanel = panel;

    // 4つの壁
    switch (panel)
    {
      case Panel.Panel0:
        transform.localPosition = new Vector2(0, 0);
        break;
      case Panel.Panel1:
        transform.localPosition = new Vector2(-1000, 0);
        break;
      case Panel.Panel2:
        transform.localPosition = new Vector2(-2000, 0);
        break;
      case Panel.Panel3:
        transform.localPosition = new Vector2(-3000, 0);
        break;

        // フォーカスの画像
    }
  }
}
