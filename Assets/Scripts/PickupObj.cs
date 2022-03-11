using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
  [SerializeField] Item.Type item;

  public void OnClickObj()
  {
    gameObject.SetActive(false);
  }
}
