using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : EnemyController
{

    [SerializeField] float speed;

    protected override void Awake()
    {
        base.Awake();
        this.transform.localScale = new Vector3(-0.5f, 0.5f, 1);
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }
    private void Update()
    {
        m_rb.velocity = new Vector2(-1,-1)* speed;
    }
}
