using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over");
            GameManager.Ins.Player.TakeDamage();
          //  GUIManager.Ins.ShowGameover(true);
        }
    }
}
