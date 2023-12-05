using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


interface IChangeIcon
{

}
public class ChangeIcon : MonoBehaviour
{
    [SerializeField] protected Sprite changeIcon;
    [SerializeField] protected Sprite defaultIcon;
    [SerializeField] Button button;

    private void Start()
    {
        button?.onClick.AddListener(() => ChangeIconComplete());
    }
    public virtual void ChangeIconComplete()
    {
       // this.GetComponent<Image>().color = Color.white;
        this.GetComponent<Image>().sprite = changeIcon;
        StartCoroutine(ChangeIconAfterTime());
    }
    IEnumerator ChangeIconAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        DefualtfIcon();
    }
    public virtual void DefualtfIcon()
    {
      //  this.GetComponent<Image>().color = Color.white;
        this.GetComponent<Image>().sprite = defaultIcon;

    }
}
