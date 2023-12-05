using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMachine : EnemyController
{
    [SerializeField] BulletGunMachine bulletGunMachine;
    [SerializeField] Transform point_gunMachine;
    private void Start()
    {
        StartCoroutine(Gunmachine());
    }
    protected override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
    }

    IEnumerator Gunmachine()
    {
        while (true)
        {
            if (Vector2.Distance(GameManager.Ins.Player.transform.position, point_gunMachine.position) < 10f)
            {
                GameObject bulletGunMachineClone = (GameObject)Poolobject.Ins.GetObj(bulletGunMachine.gameObject);
                bulletGunMachineClone.transform.position = point_gunMachine.position;
                bulletGunMachineClone.SetActive(true);
                AudioController.Ins.PlaySound(AudioController.Ins.machineSound);

            }

            yield return new WaitForSeconds(1.2f);
        }
    }
}