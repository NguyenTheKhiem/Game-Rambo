using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolobject : SIngleton<Poolobject>
{

    Dictionary<GameObject, List<GameObject>> listObj = new Dictionary<GameObject, List<GameObject>>();
    public Object GetObj(GameObject defaultprefab)
    {
        if (listObj.ContainsKey(defaultprefab))
        {
            foreach (GameObject g in listObj[defaultprefab])
            {
                if (g.activeSelf)
                    continue;
                return g;
            }
            GameObject g2 = Instantiate(defaultprefab, transform.position, Quaternion.identity);
            g2.SetActive(false);
            listObj[defaultprefab].Add(g2);
            return g2;
        }

        List<GameObject> newList = new List<GameObject>();
        GameObject g3 = Instantiate(defaultprefab, transform.position, Quaternion.identity);
        newList.Add(g3);
        listObj.Add(defaultprefab, newList);
        g3.SetActive(false);
        return g3;

    }

}
