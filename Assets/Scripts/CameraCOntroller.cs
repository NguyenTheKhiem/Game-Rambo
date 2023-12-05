using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCOntroller : MonoBehaviour
{
    //[SerializeField] Transform player;
    [SerializeField] Vector2 offset;
    void Update()
    {
        if (GameManager.Ins.Player == null || GameManager.Ins.Joystick.Horizontal<0)
            return;
        if(Camera.main.transform.position.x <= GameManager.Ins.Player.transform.position.x)
        {
            Vector3 pos = GameManager.Ins.Player.transform.position + (Vector3)offset;
            pos.y = Camera.main.transform.position.y;
            pos.z = Camera.main.transform.position.z;
            Camera.main.transform.position = pos;
        }
        //Vector3 pos = GameManager.Ins.Player.transform.position + (Vector3)offset;
        //pos.y = Camera.main.transform.position.y;
        //pos.z = Camera.main.transform.position.z;
        //Camera.main.transform.position = pos;


    }
}
