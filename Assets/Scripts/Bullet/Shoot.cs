using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private void OnEnable()
    {
       
        StartCoroutine(UnActiveAfterTime());
    }
   IEnumerator UnActiveAfterTime()
    {
        yield return new WaitForSeconds(0.3f);
        this.gameObject.SetActive(false);
    }
  
}
