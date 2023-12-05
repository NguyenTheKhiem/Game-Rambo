using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] float fireSpeed = 0.5f;
    float timeFireCount = 0;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shoot;
    [SerializeField] Transform pointBllet;
    int stateBullet = 1;
    BulletBase curStateBullet;

    public int StateBullet { get => stateBullet; set => stateBullet = value; }

    private void Start()
    {
        curStateBullet = bulletPrefab.gameObject.GetComponent<NomalBullet>();
        if (curStateBullet != null)
        {
            curStateBullet._Start();
        }
    }
    private void Update()
    {
        //if()

        timeFireCount -= Time.deltaTime;

        //    if (stateBullet == 0)
        //    {
        //        //Debug.Log("chuyen sang muti Bullet");
        //        curStateBullet = bulletPrefab.GetComponent<MutiBullet>();
        //        curStateBullet._Start();
        //    }
        //    else
        //    {

        //       // Debug.Log("chuyen sang n0mal Bullet");

        //        curStateBullet = bulletPrefab.GetComponent<NomalBullet>();
        //        curStateBullet._Start();


        //}
    }
    public void UpdateSpeed(bool isDead)
    {
        curStateBullet._Update(isDead);
    }
    public void ChangeBullet(int stateBullet)
    {
        if (stateBullet == 0)
        {
            //Debug.Log("chuyen sang muti Bullet");
            curStateBullet = bulletPrefab.GetComponent<MutiBullet>();
            curStateBullet._Start();
        }
        else
        {

            // Debug.Log("chuyen sang n0mal Bullet");

            curStateBullet = bulletPrefab.GetComponent<NomalBullet>();
            curStateBullet._Start();


        }
    }
    public void Fire()
    {
        if (timeFireCount > 0)
            return;

       // if (Input.GetMouseButtonDown(0))
        //{

            timeFireCount = fireSpeed;
            Bullet();
            Shoot();
       // }

    }
    void Shoot()
    {
        GameObject shoot = (GameObject)Poolobject.Ins.GetObj(this.shoot);
        shoot.transform.position = pointBllet.position;
        shoot.transform.SetParent(pointBllet);
        Quaternion q = shoot.transform.rotation;
       //q.eulerAngles = new Vector3(0,0, GameManager.Ins.Player.transform.localScale.x == 0.5f ? 0 : 180);
        shoot.transform.rotation = q;
        shoot.SetActive(true);
    }
    void Bullet()
    {

       if(curStateBullet!= null)
        {
            curStateBullet.Fire(bulletPrefab, pointBllet);
        }
           
        

    }
}
