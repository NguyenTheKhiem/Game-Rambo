using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    public float bulletSpeed;
    public float _curBulletSpeed;
    Coroutine deActiveWait = null;
    public abstract void _Start();
    public abstract void _Update(bool isDead);
    public abstract void Fire(GameObject bulletPrefab,Transform point);
    private void OnEnable()
    {
        StartCoroutine(DeActiveAfterTime());
    }
    private void OnDisable()
    {
        if (deActiveWait != null)
        {
            StopCoroutine(DeActiveAfterTime());
            deActiveWait = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("wall"))
        {
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator DeActiveAfterTime()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
