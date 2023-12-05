using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
   protected Rigidbody2D m_rb;
    Coroutine deActiveWait = null;
    protected virtual void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void OnEnable()
    {
        StartCoroutine(DeActiveAfterTime());
    }
    protected virtual void OnDisable()
    {
        if (deActiveWait != null)
        {
            StopCoroutine(DeActiveAfterTime());
            deActiveWait = null;
        }
    }
    protected virtual void Update()
    {
        m_rb.velocity = -moveSpeed * this.transform.right;
    }
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (GameManager.Ins.Player.PlayerState == PlayerController.State.invisible || GameManager.Ins.State == GameManager.GameState.GameWin) 
            return;
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Ins.Player.TakeDamage();
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator DeActiveAfterTime()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
