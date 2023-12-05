using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : EnemyController
{
    [SerializeField] BulletEnemy bulletEnemy;
    [SerializeField] Transform pointGun;
    [SerializeField] GameObject gun;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        StartCoroutine(CheckPointPlayer());
    }
    private void Update()
    {
        Vector2 dir = GameManager.Ins.Player.transform.position - gun.transform.position;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if(GameManager.Ins.Player.transform.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Quaternion q = gun.transform.rotation;
            q.eulerAngles = new Vector3(0, 0, angle );
            gun.transform.rotation = q;
        }
        else
        {
            this.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            Quaternion q = gun.transform.rotation;
            q.eulerAngles = new Vector3(0, 0, angle-180);
            gun.transform.rotation = q;
        }
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    IEnumerator CheckPointPlayer()
    {
       
        while (true)
        {
            if (Vector2.Distance(GameManager.Ins.Player.transform.position, this.transform.position) < 10f)
            {
                GameObject bulletEnemyClone = (GameObject)Poolobject.Ins.GetObj(bulletEnemy.gameObject);
                bulletEnemyClone.transform.position = pointGun.position;
                bulletEnemyClone.SetActive(true);
                AudioController.Ins.PlaySound(AudioController.Ins.shootingSoundEnemy);

            }

            yield return new WaitForSeconds(1f);
        }
    }
}
