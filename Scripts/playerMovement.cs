using System.Collections;
using System.Collections.Generic;
using UnityEngine;//namespace
using UnityEngine.UI;

public class playerMovement : MonoBehaviour//调用unity基础代码
{
    public static playerMovement Instance { get; private set; }
    [SerializeField] Rigidbody2D myRigidbody;//用[SerializeField]可以在unity版面里产生一个玩意，把含有 要用的component的组件拖进去
    [SerializeField]Collider2D myCollider;
    [SerializeField] float mySpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] GameObject myBulletPrefab;
    [SerializeField] GameObject myBallPrefab;
    [SerializeField] GameObject hurtPrefab;
    [SerializeField] GameObject[] Heart;
    [SerializeField] int coin;
    public Text coinNum;
    public bool bossStart = false;

    public int health;
    //做血量

    public Vector2 InitPos;
    private bool isJumping=false;
    private void Start()
    {
        InitPos = this.transform.position;
    }
    private void GetHurt()
    {
        GameObject hurtsprite = Instantiate(hurtPrefab);
        hurtsprite.transform.parent = this.transform;
        hurtsprite.transform.localPosition = new Vector3(0f, 0.75f, 0);
        Destroy(hurtsprite, 0.4f);
        for (int i = 4; i>=0; i--)
        {
            if(Heart[i].activeSelf == true)
            {
                Heart[i].gameObject.SetActive(false);
                health--;
                break;
            }
        }
    }
    private void Update()
    {
        if(this.transform.position.y<-20)
        {
            GetHurt();
            InitPoristion();
        }    
        Vector2 t_moveSpeed = myRigidbody.velocity;
        t_moveSpeed.x = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //moveleft
            //this.GetComponent<Rigidbody2D>();
            //若调用的rigidbody不在此物体上时：[SerializeField]Rigidbody2D _rig; 直接调用_rig
            this.transform.localScale = new Vector2(-1, 1);
            t_moveSpeed.x -= mySpeed;

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.localScale = new Vector2(1, 1);
            t_moveSpeed.x += mySpeed;
        }//bug:左右一起按的时候 由于代码顺序执行 先向左后一直向右
        if (Input.GetKeyDown(KeyCode.Space)&&isJumping==false)
        {
            
            t_moveSpeed.y = jumpSpeed;
            isJumping = true;
            this.transform.SetParent(null);
        }
        myRigidbody.velocity = t_moveSpeed;//不能直接改变 需要创建新二维向量
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject t_bullet=Instantiate(myBulletPrefab,this.transform.position,Quaternion.identity);
            Vector2 t_bulletDirection = Vector2.zero;
            if(this.transform.localScale.x>0)
            {
                t_bulletDirection = Vector2.right;
            }
            else
            {
                t_bulletDirection = Vector2.left;
            }
            t_bullet.GetComponent<pullet>().Init(t_bulletDirection);//获取子弹prefab上的脚本的函数
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject t_ball = Instantiate(myBallPrefab, this.transform.position, Quaternion.identity);
            Vector2 t_ballDirection = Vector2.zero;
            if (this.transform.localScale.x > 0)
            {
                t_ballDirection = Vector2.right;
            }
            else
            {
                t_ballDirection = Vector2.left;
            }
            t_ball.GetComponent<BALL>().Init(t_ballDirection);//获取子弹prefab上的脚本的函数
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            isJumping = false;
        }

        /* if(collision.collider.transform.position.y<=this.transform.position.y)
         {
            isJumping = false;
         }*/
        if(collision.gameObject.GetComponent<platformMove>()!=null)
        {
            this.transform.SetParent(collision.transform);
        }
        if (collision.gameObject.tag == "enemy")
        {
            GetHurt();
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<platformMove>()==null)
        {
            this.transform.SetParent(null);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            coin++;
            coinNum.text = coin.ToString();
        }
        if (collision.gameObject.tag == "BOSS")
        {
            GetHurt();
        }
        if (collision.gameObject.tag == "enemyBullet")
        {
            GetHurt();
        }
        if (collision.gameObject.tag == "airWall")
        {
            bossStart = true;
        }
    }
    public void InitPoristion()
    {
        this.transform.position = InitPos;
    }
   
}
