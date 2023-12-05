using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFort : EnemyController
{
    [SerializeField] GameObject bulletFortMIni;
    [SerializeField] Transform point;
    [SerializeField] GameObject Itop;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }
    private void Start()
    {
        StartCoroutine(CheckPointPlayer());
    }
    private void Update()
    {
        Vector2 dir = GameManager.Ins.Player.transform.position - Itop.transform.position;
        dir = dir.normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //if (GameManager.Ins.Player.transform.position.x > this.transform.position.x)
        //{
          //  this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            Quaternion q = Itop.transform.rotation;
            q.eulerAngles = new Vector3(0, 0, angle-90);
            Itop.transform.rotation = q;
        //}
        //else
        //{
        //    this.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        //    Quaternion q = Itop.transform.rotation;
        //    q.eulerAngles = new Vector3(0, 0, angle - 180);
        //    Itop.transform.rotation = q;
        //}
    }
    IEnumerator CheckPointPlayer()
    {

        while (true)
        {
            if (Vector2.Distance(GameManager.Ins.Player.transform.position, this.transform.position) < 10f)
            {
                GameObject bulletEnemyClone = (GameObject)Poolobject.Ins.GetObj(bulletFortMIni.gameObject);
                bulletEnemyClone.transform.position = point.position;
                bulletEnemyClone.SetActive(true);
                AudioController.Ins.PlaySound(AudioController.Ins.shootingSoundEnemy);

            }

            yield return new WaitForSeconds(1f);
        }
    }
}
