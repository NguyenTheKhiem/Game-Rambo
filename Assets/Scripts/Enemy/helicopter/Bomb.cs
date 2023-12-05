using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("platform"))
        {
            GameManager.Ins.Vfx_Bomb(this.transform);
            this.gameObject.SetActive(false);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Ins.Player.TakeDamage();
            GameManager.Ins.Vfx_Bomb(this.transform);
            this.gameObject.SetActive(false);
        }
    }
}
