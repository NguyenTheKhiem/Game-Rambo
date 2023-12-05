using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopImage : MonoBehaviour
{
    Texture texture;
    [SerializeField] int pixelPerUnit;
    //[SerializeField] Transform player;
   [SerializeField] float intGameWight;

    private void Awake()
    {
        texture = this.GetComponent<SpriteRenderer>().sprite.texture;
        intGameWight = texture.width / pixelPerUnit;
    }
    
    void Update()
    {
        if (GameManager.Ins.Player == null)
            return;
       if(Mathf.Abs(GameManager.Ins.Player.transform.position.x - this.transform.position.x)>= intGameWight)
        {
            Vector2 pos = this.transform.position;
            pos.x = GameManager.Ins.Player.transform.position.x;
            this.transform.position = pos;
        }
    }
}
