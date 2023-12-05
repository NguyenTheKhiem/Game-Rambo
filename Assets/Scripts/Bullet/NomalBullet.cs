using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : BulletBase
{
    public override void _Start()
    {
        bulletSpeed = 10f;
        _curBulletSpeed = bulletSpeed;
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
    public override void Fire(GameObject bulletPrefab,Transform pointBllet)
    {
        GameObject bullet = (GameObject)Poolobject.Ins.GetObj(bulletPrefab);
        bullet.transform.position = pointBllet.position;
        Quaternion q = bullet.transform.rotation;
        q.eulerAngles = new Vector3(0,0, GameManager.Ins.Player.transform.localScale.x == 0.5f ? 0 : -180);
        bullet.transform.rotation = q;

        bullet.SetActive(true);
        AudioController.Ins.PlaySound(AudioController.Ins.shootingSound);

        bullet.GetComponent<Rigidbody2D>().velocity = _curBulletSpeed * bullet.transform.right;
    }


}
