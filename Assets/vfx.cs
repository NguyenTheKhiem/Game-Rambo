using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfx : MonoBehaviour
{
    private void OnEnable()
    {
      
        StartCoroutine(UnActiveAfterTime());
    }
    IEnumerator UnActiveAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}
