using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItemUI : MonoBehaviour
{
   public void UpdateHP( bool isshow)
    {
        this.gameObject.SetActive(isshow);
    }
}
