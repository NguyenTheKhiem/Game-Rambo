using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected Rigidbody2D m_rb;
    [SerializeField] float hP;
    float cur_hp;

    protected virtual void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        cur_hp = hP;
    }
    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bullet"))
        {
            col.gameObject.SetActive(false);
            if (hP <= 0)
            {
                this.gameObject.SetActive(false);
                GameManager.Ins.Vfx(this.transform);
            }
            hP--;
        }
        if (col.gameObject.CompareTag("wall"))
        {
            this.gameObject.SetActive(false);

        }
        if (GameManager.Ins.Player.PlayerState == PlayerController.State.invisible)
            return;
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Ins.Player.TakeDamage();

        }
       
       
    }

protected virtual void OnCollisionEnter2D(Collision2D col)
{
        if (col.gameObject.CompareTag("bullet"))
        {
            col.gameObject.SetActive(false);
            cur_hp--;
            if (cur_hp <= 0)
            {
                this.gameObject.SetActive(false);
                GameManager.Ins.Vfx(this.transform);
            }
            cur_hp--;
        }
        if (col.gameObject.CompareTag("wall"))
        {
            this.gameObject.SetActive(false);

        }
        if (GameManager.Ins.Player.PlayerState == PlayerController.State.invisible)
        return;
    if (col.gameObject.CompareTag("Player"))
    {
        GameManager.Ins.Player.TakeDamage();

    }
   
    
}
}
