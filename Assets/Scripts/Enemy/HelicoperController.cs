using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicoperController : EnemyController
{
    [SerializeField] float speed;
    [SerializeField] GameObject bommb;

    //private void Start()
    //{
    //    StartCoroutine(SpawnBomb());
    //}
    
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        StartCoroutine(SpawnBomb());
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }
    private void Update()
    {
        m_rb.velocity = new Vector2(-1, -1) * speed;
    }
    IEnumerator SpawnBomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            GameObject boombClone = (GameObject)Poolobject.Ins.GetObj(bommb);
            boombClone.transform.position = this.transform.position;
            boombClone.SetActive(true);
        }
    }
}
