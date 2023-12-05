using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : BulletEnemyBase
{
    Vector3 dir;

    protected override void Awake()
    {
        base.Awake();
       // m_rb = GetComponent<Rigidbody2D>();
    }

    protected override void OnEnable()
    {
        dir = GameManager.Ins.Player.transform.position - this.transform.position;
            dir = dir.normalized;
        base.OnEnable();
    }

    protected override void Update()
    {
        m_rb.velocity = dir * moveSpeed;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
    }

}
