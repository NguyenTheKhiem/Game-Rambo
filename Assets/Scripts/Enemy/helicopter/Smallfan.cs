using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smallfan : MonoBehaviour
{
    [SerializeField] float angle;
    float cur_angle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        cur_angle += angle;
        Quaternion q = this.transform.rotation;
        q.eulerAngles = new Vector3(0, 0, cur_angle);
        this.transform.rotation = q;
    }
}
