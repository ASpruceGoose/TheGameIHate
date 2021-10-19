using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{
    [SerializeField] GameObject bossBullet;
    [SerializeField] GameObject giftPrefab;
    [SerializeField] float shootTime;
    private float myCD;
    public GameObject player;
    [SerializeField] GameObject hurtPrefab;
    public int enemyHealth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(giftPrefab, this.transform.position, Quaternion.identity);
        }
        if(GameObject.Find("player").GetComponent<playerMovement>().bossStart ==true)
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
        Vector2 shootDirection= Vector2.zero;
        shootDirection= new Vector2(player.transform.position.x - this.transform.position.x, player.transform.position.y - this.transform.position.y);
        shootDirection = shootDirection.normalized;
        GameObject t_bullet = Instantiate(bossBullet, this.transform.position, Quaternion.identity);
        t_bullet.GetComponent<enemyBullet>().Init(shootDirection);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            GameObject hurtsprite = Instantiate(hurtPrefab);
            hurtsprite.transform.parent = this.transform;
            hurtsprite.transform.localPosition = new Vector3(0.5f, -0.7f, 0);
            Destroy(hurtsprite, 0.2f);
            enemyHealth--;
        }
    }
}
