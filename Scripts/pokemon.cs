using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pokemon : MonoBehaviour
{
    [SerializeField] GameObject myBullet;
    [SerializeField] float shootTime;
    [SerializeField] GameObject hurtPrefab;
    private float myCD;
    public GameObject BOSS;
    public int Health;
    // Start is called before the first frame update
    void Start()
    {
        BOSS = GameObject.Find("BOSS1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (GameObject.Find("player").GetComponent<playerMovement>().bossStart == true)
        {
            if (myCD <= 0)
            {
                Shoot();
                myCD = shootTime;
            }
            else
            {
                myCD -= Time.deltaTime;
            }
        }

    }
    private void Shoot()
    {
        Vector2 shootDirection = Vector2.zero;
        shootDirection = new Vector2(BOSS.transform.position.x - this.transform.position.x, BOSS.transform.position.y - this.transform.position.y);
        shootDirection = shootDirection.normalized;
        GameObject t_bullet = Instantiate(myBullet, this.transform.position, Quaternion.identity);
        t_bullet.GetComponent<pullet>().Init(shootDirection);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy"|| collision.gameObject.tag == "enemyBullet")
        {
            GameObject hurtsprite = Instantiate(hurtPrefab);
            hurtsprite.transform.parent = this.transform;
            hurtsprite.transform.localPosition = new Vector3(0.5f, -0.7f, 0);
            Destroy(hurtsprite, 0.2f);
            Health--;
        }
    }
}
