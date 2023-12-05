using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
   [SerializeField] List<LoopImage> _loopingBg = new List<LoopImage>();
   [SerializeField] List<float> speedsBg = new List<float>();
   [SerializeField] float way;

    void Update()
    {
        if (GameManager.Ins.State != GameManager.GameState.Playgame)
            return;
       if (GameManager.Ins.Player != null )
        {
        way = GameManager.Ins.Player.transform.lossyScale.x < 0 ? 1 : -1;
       
        for (int i = 0; i < _loopingBg.Count; i++)
        {
            _loopingBg[i].transform.position += new Vector3(way*speedsBg[i] * Time.deltaTime, 0, 0);
        }

        }
            
    }
}
