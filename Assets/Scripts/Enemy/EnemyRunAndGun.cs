using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunAndGun : EnemyController
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform pointBullet;
    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(FIre());
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }
    private void Update()
    {
        m_rb.velocity = new Vector2(-1, -1) * moveSpeed;
    }
    IEnumerator FIre()
    {
        while (true)
        {
                GameObject bulletClone = (GameObject)Poolobject.Ins.GetObj(bullet.gameObject);
                bulletClone.transform.position = pointBullet.position;
                bulletClone.SetActive(true);
            AudioController.Ins.PlaySound(AudioController.Ins.shootingSoundEnemy);
            yield return new WaitForSeconds(1f);
        }
    }
}
