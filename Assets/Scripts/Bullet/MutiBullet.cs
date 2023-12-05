using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutiBullet : BulletBase
{
    [SerializeField] int bulletAmount;
    [SerializeField] float startAngle;
    [SerializeField] float endAngle;
    [SerializeField] Vector2 bulletMoveDirection;

    public override void _Start()
    {
        bulletSpeed = 10f;
        _curBulletSpeed = bulletSpeed;
        bulletAmount = 3;
        startAngle = 45;
        endAngle = 120;
    }
    public override void _Update(bool isDead)
    {
        if (isDead == false)
        {
             _curBulletSpeed += 5f;
        }
        else
        {
            _curBulletSpeed = bulletSpeed;
        }
       
    }
    public override void Fire(GameObject bulletPrefab,Transform point)
    {
        if (GameManager.Ins.Player.transform.localScale.x < 0)
        {
            startAngle = -45;
            endAngle = -120;
        }else if(GameManager.Ins.Player.transform.localScale.x > 0)
        {
            startAngle = 60;
            endAngle = 120;
        }
        float stepAngle = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;
        for (int i = 0; i < bulletAmount; i++)
        {
            float bulletDirX = point.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulletDirY = point.position.y + Mathf.Cos((angle * Mathf.PI) / 180);
            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletdir = (bulletMoveVector - point.position).normalized;
          
            GameObject bullet = (GameObject)Poolobject.Ins.GetObj(bulletPrefab.gameObject);
            bullet.transform.position = point.position;
            bullet.transform.rotation = point.rotation;
            bullet.SetActive(true);
            AudioController.Ins.PlaySound(AudioController.Ins.mutiBulletSound);

            bullet.GetComponent<Rigidbody2D>().velocity = bulletdir * _curBulletSpeed;
            angle += stepAngle;
        }
    }
}
