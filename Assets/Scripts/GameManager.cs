using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SIngleton<GameManager>
{
    [SerializeField] PlayerController player;
    [SerializeField] Joystick joystick;
    [SerializeField] EnemyRun enemyRunPb;
    [SerializeField] GameObject enemyRunAndGunPb;
    [SerializeField] GameObject helicoperPb;

    [SerializeField] int enemyRun;
    [SerializeField] int enemyRunAndGun;
    [SerializeField] Transform point_enemyRun;
    [SerializeField] Transform point_enemyRunAndGun;
    [SerializeField] Transform point_helicoper;
    [SerializeField] GameObject vfx;
    [SerializeField] GameObject vfx_bomb;
    [SerializeField] GameState state;

    int curEnemyRun;
    int curEnemyRunAndGun;

    public PlayerController Player { get => player;  }
    public GameState State { get => state; set => state = value; }
    public Joystick Joystick { get => joystick; set => joystick = value; }

    private void Start()
    {
        GUIManager.Ins.MainMenu(true);
        state = GameState.Menu;
        curEnemyRun = enemyRun;
        curEnemyRunAndGun = enemyRunAndGun;

    }
    //private void Update()
    //{
    //    if (state != GameState.Playgame)
    //        return;
    //    if (player.CurHp <= 0)
    //    {
    //        GUIManager.Ins.ShowGameover(true);
    //    }
    //}
    public void shootBtn()
    {
        player.Attack();
    }
    public void JumpBtn()
    {
        player.Jump();
    }
    public void Vfx(Transform toado)
    {
        GameObject vfxClone = (GameObject)Poolobject.Ins.GetObj(this.vfx);
        vfxClone.transform.position = toado.position;
        vfxClone.SetActive(true);
      
    }
    public void Vfx_Bomb(Transform toado)
    {
        GameObject vfxClone = (GameObject)Poolobject.Ins.GetObj(this.vfx_bomb);
        vfxClone.transform.position = toado.position;
        vfxClone.SetActive(true);

    }
    public void PauseBtn()
    {
        Time.timeScale = 0f;
        GUIManager.Ins.ShowPauseDialog(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GUIManager.Ins.ShowPauseDialog(false);
    }
    public void OutPlaygame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
    public void PlayBtn()
    {
        GUIManager.Ins.MainMenu(false);
        state = GameState.Playgame;
        player = Instantiate(player, new Vector3(-3f, 4.4f, 0f), Quaternion.identity);
        GUIManager.Ins.DrawHPBarGrid(player.CurHp, player.MaxHp);
        StartCoroutine(CheckPointEnemyRun());
        StartCoroutine(CheckPointEnemyRunAndGun());
        StartCoroutine(CheckPointHelicpoer());
        AudioController.Ins.PlayBackgroundMusic();
    }
    IEnumerator CheckPointHelicpoer()
    {
        bool check = true;
        while (check)
        {
            if (Vector2.Distance(player.transform.position, point_helicoper.position) < 10f)
            {
                GameObject helicoyerClone = (GameObject)Poolobject.Ins.GetObj(helicoperPb.gameObject);
                helicoyerClone.transform.position = point_helicoper.position;
                helicoyerClone.SetActive(true);
                check = false;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator CheckPointEnemyRun()
    {
        bool check = true;
        while (check)
        {
            if(Vector2.Distance(player.transform.position, point_enemyRun.position) < 7f)
            {
            StartCoroutine(SpawnEnemyRun());
               check = false;
            }
           
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator CheckPointEnemyRunAndGun()
    {
        bool check = true;
        while (check)
        {
            if (Vector2.Distance(player.transform.position, point_enemyRunAndGun.position) < 7f)
            {
                StartCoroutine(SpawnEnemyRunAndGun());
                check = false;
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator SpawnEnemyRun()
    {
        while (curEnemyRun > 0)
        {
            GameObject enemyRunClone = (GameObject)Poolobject.Ins.GetObj(enemyRunPb.gameObject);
            enemyRunClone.transform.position = point_enemyRun.position;
            enemyRunClone.SetActive(true);
            yield return new WaitForSeconds(1f);
            curEnemyRun--;
        }
    }
    IEnumerator SpawnEnemyRunAndGun()
    {
        while (curEnemyRunAndGun > 0)
        {
            GameObject enemyRunANdGunClone = (GameObject)Poolobject.Ins.GetObj(enemyRunAndGunPb.gameObject);
            enemyRunANdGunClone.transform.position = point_enemyRunAndGun.position;
            enemyRunANdGunClone.SetActive(true);
            yield return new WaitForSeconds(1f);
            curEnemyRunAndGun--;
        }
    }
    public enum GameState
    {
        Menu,
        Playgame,
        Gameover,
        GameWin
    }

}
