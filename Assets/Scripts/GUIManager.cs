using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : SIngleton<GUIManager>
{
    [SerializeField] HpItemUI hpItemPb;
    [SerializeField] Transform hpBarGrid;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject Mainmenu;
    [SerializeField] GameObject gamePlay;
    [SerializeField] GameObject pauseDialog;

    public void MainMenu(bool ishow)
    {
        if (Mainmenu)
        {
            
            Mainmenu.gameObject.SetActive(ishow);
        }
        if (gamePlay)
        {
            gamePlay.gameObject.SetActive(!ishow);
        }
    }
    public void ShowPauseDialog(bool isshow)
    {
        if (pauseDialog)
        {
            pauseDialog.SetActive(isshow);
        }
    }
    public void ShowGameover(bool ishow)
    {
        if (gameoverPanel)
        {
            gameoverPanel.gameObject.SetActive(ishow);
        }
        StartCoroutine(DontShowGameoverAfterTime());
       
    }
    public void ShowWinPanel(bool ishow)
    {
        if (winPanel)
        {
            winPanel.gameObject.SetActive(ishow);
        }
        StartCoroutine(DontShowWinAfterTime());

    }
    IEnumerator DontShowWinAfterTime()
    {
        yield return new WaitForSeconds(2f);
        ShowWinPanel(false);
        SceneManager.LoadScene(0);
    }
    IEnumerator DontShowGameoverAfterTime()
    {
        yield return new WaitForSeconds(2f);
        ShowGameover(false);
        SceneManager.LoadScene(0);
    }
    public void DrawHPBarGrid(int curHp,int maxHp)
    {
        ClearChild(hpBarGrid);
        for (int i = 1; i <= maxHp; i++)
        {
            var hpItemClone = Instantiate(hpItemPb, Vector3.zero, Quaternion.identity);
            hpItemClone.transform.SetParent(hpBarGrid);
            hpItemClone.transform.localScale = Vector3.one;
            hpItemClone.transform.localPosition = Vector3.zero;
            if (i > curHp)
            {
                hpItemClone.UpdateHP(false);
            }
            else
            {
                hpItemClone.UpdateHP(true);
            }
        }
    }
    public void ClearChild( Transform root)
    {
        for (int i = 0; i < root.childCount; i++)
        {
            var child = root.GetChild(i);
            if (!child)
                continue;
            Destroy(child.gameObject);
        }
    }
}
