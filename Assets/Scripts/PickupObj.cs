using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
  // [SerializeField] Item.Type item;
  [SerializeField] Item item;

  public void OnClickObj()
  {
    ItemBox.instance.SetItem(item);
    gameObject.SetActive(false);
  }
}
