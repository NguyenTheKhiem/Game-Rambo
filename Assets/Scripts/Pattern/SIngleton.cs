using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIngleton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T _ins;
    public static T Ins => _ins;
    private void Awake()
    {
        if(_ins == null)
        {
            _ins = GetComponent<T>();
            return;
        }
        if(_ins.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this);
        }
    }
}
