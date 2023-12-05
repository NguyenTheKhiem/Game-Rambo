using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float timeInvisible;
    Rigidbody2D m_rb;
    [SerializeField] Joystick joystick;
    int maxHp = 5;
    int curHp;
    Vector3 quayphai = new Vector3(0.5f, 0.5f, 1);
    [SerializeField] bool _isJump;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform pointBllet;
    [SerializeField] GunController _gun;
    [SerializeField] State playerState;
    public Vector3 offset;
     
   public Animator anim;

    public int MaxHp { get => maxHp; }
    public int CurHp { get => curHp; set => curHp = value; }
    public State PlayerState { get => playerState; set => playerState = value; }

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
        curHp = maxHp;
    }

    private void Update()
    {
        if (GameManager.Ins.State != GameManager.GameState.Playgame)
            return;
        //Moving();
       // Jump();
        CheckPlatform();
        MoveJoystick();
     //   Attack();
        if (Input.GetKeyDown(KeyCode.C))
        {

            AddHp();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {

            TakeDamage();
        }
    }
    public void AddHp()
    {
        curHp += 1;
        curHp = Mathf.Clamp(curHp, 0, maxHp);
        GUIManager.Ins.DrawHPBarGrid(curHp, maxHp);
    }
    public void TakeDamage()
    {
        if (curHp <= 0)
        {
            Debug.Log("GameOver");
            GUIManager.Ins.ShowGameover(true);
            return;
        }
        curHp -= 1;
        curHp = Mathf.Clamp(curHp, 0, maxHp);
        GUIManager.Ins.DrawHPBarGrid(curHp, maxHp);
        // _gun.StateBullet = 1;
        _gun.ChangeBullet(1);
        _gun.UpdateSpeed(true);
        int LayerIgnoreRaycast = LayerMask.NameToLayer("invisible");
        this.gameObject.layer = LayerIgnoreRaycast;
        Debug.Log("Current layer: " + gameObject.layer);

        Vector3 pos = Camera.main.transform.position;
        pos.z = 0f;
        pos.y = 5;
        this.transform.position = pos;
        Invisible();
        anim.SetBool("jump", true);
        StartCoroutine(jumpAfterTime());
    }
    public void Invisible()
    {
        playerState = State.invisible;
        anim.SetBool("invisible", true);
        StartCoroutine(StateInvisibleAfterTime());
    }
    IEnumerator StateInvisibleAfterTime()
    {
        yield return new WaitForSeconds(timeInvisible);
         anim.SetBool("invisible", false);
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Player");
        this.gameObject.layer = LayerIgnoreRaycast;
        playerState = State.nomal;
    }
   public void Attack()
    {
        _gun.Fire();
    }
    void MoveJoystick()
    {
        
        anim.SetBool("run", true);
        m_rb.velocity = new Vector2(GameManager.Ins.Joystick.Horizontal * moveSpeed, m_rb.velocity.y);
         float vertical = GameManager.Ins.Joystick.Vertical;
        //Vector2 dir = new Vector2(GameManager.Ins.Joystick.Horizontal, GameManager.Ins.Joystick.Vertical);
        //dir = dir.normalized;


        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Debug.Log("angleplayer" + angle);
        //Quaternion q = _gun.transform.parent.rotation;
        //q.eulerAngles = new Vector3(0, 0, angle);
        //_gun.transform.parent.rotation = q;
        
        if (m_rb.velocity.x > 0)
        {

            transform.localScale = quayphai;
          
        }
        else if (m_rb.velocity.x < 0)
        {

            transform.localScale = new Vector3(-quayphai.x,quayphai.y,quayphai.z);
            //if (vertical < 0)
            //{
            //    anim.SetBool("prone_left", true);
            //    transform.localScale = new Vector3(quayphai.x, -quayphai.y, quayphai.z);
            //}
           // StartCoroutine(test());
           // transform.localScale = temp;
        }
        else
        {

           
            //playerState = State.idle;
            anim.SetBool("run", false);
        }
        if (vertical < 0)
        {
            if (m_rb.velocity.x <= 0)
            {
                anim.SetBool("prone_left", true);

            }
            else
            {
                anim.SetBool("prone", true);
            }
        }
        else
        {
            anim.SetBool("prone", false);
            anim.SetBool("prone_left", false);
        }
    }

    void Moving()
    {
        anim.SetBool("run", true);
        m_rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, m_rb.velocity.y);
        if(m_rb.velocity.x > 0)
        {
            
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }else if (m_rb.velocity.x < 0)
        {
            Debug.Log(m_rb.velocity.x);
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else
        {
            
            anim.SetBool("run", false);
        }
    }
    public void Jump()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && _isJump == true)
        //{
        //    m_rb.AddForce(new Vector2(0, jumpForce));
        //    Debug.Log("nhay");
        //    anim.SetBool("jump", true);
        //    StartCoroutine(jumpAfterTime());
        //    //_isJump = false;
        //}
        if (_isJump == false)
            return;
            m_rb.AddForce(new Vector2(0, jumpForce));
            Debug.Log("nhay");
            anim.SetBool("jump", true);
            StartCoroutine(jumpAfterTime());
            //_isJump = false;
        
    }
    IEnumerator jumpAfterTime()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("jump", false);
    }
    void CheckPlatform()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position - new Vector3(0.15f,0.2f,0), Vector2.down,0.5f);
        Debug.DrawRay(this.transform.position - new Vector3(0.15f, 0.2f, 0), Vector2.down*0.5f, Color.red);
        if (hit.collider == null)
        {

            //anim.SetBool("jump", false);
            _isJump = false;
        }
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("platform"))
            {
               // anim.SetBool("jump", false);
                _isJump = true;
                
            }
        }


    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("mutibullet"))
        {
            collision.gameObject.SetActive(false);
            _gun.ChangeBullet(0);
        }
        if (collision.gameObject.CompareTag("speedbullet"))
        {
            collision.gameObject.SetActive(false);
            _gun.UpdateSpeed(false);
        }
        if (collision.gameObject.CompareTag("winpoint"))
        {
            GUIManager.Ins.ShowWinPanel(true);
            GameManager.Ins.State = GameManager.GameState.GameWin;
        }
    }
    public enum State
    {
        nomal,
        invisible
    }
}
