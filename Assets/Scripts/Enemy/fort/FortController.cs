using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortController : EnemyController
{
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bulletFort;
    [SerializeField] Transform point;
    [SerializeField] GameObject Itop;
    float angle;
    void Start()
    {
        angle = 0 ;
        StartCoroutine(CheckPointPlayer());
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    void Fire()
    {
        //Debug.Log(angle);
        //float dirX = point.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
        //float dirY = point.position.y + Mathf.Cos((angle * Mathf.PI) / 180);
        float dirX =  Mathf.Sin((angle * Mathf.PI) / 180);
        float dirY =  Mathf.Cos((angle * Mathf.PI) / 180);
        Vector3 bulletMoveVector = new Vector3(dirX, dirY, 0f);
        Vector2 bulletDir = (bulletMoveVector - point.position).normalized;

        float angleItop = Mathf.Atan2(dirX, dirY) * Mathf.Rad2Deg;
        Quaternion q = Itop.transform.rotation;
        q.eulerAngles = new Vector3(0, 0, -angleItop);
        Itop.transform.rotation = q;
       
        GameObject bullet = (GameObject)Poolobject.Ins.GetObj(bulletFort);
        bullet.transform.position = point.position;
        bullet.transform.rotation = point.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDir * bulletSpeed;
        angle += 35;

    }
    IEnumerator CheckPointPlayer()
    {

        while (true)
        {
            if (Vector2.Distance(GameManager.Ins.Player.transform.position, this.transform.position) < 10f)
            {
                Fire();
                AudioController.Ins.PlaySound(AudioController.Ins.shootingSoundEnemy);

            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
