using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    [SerializeField] float mySpeed;
    [SerializeField] Rigidbody2D rig;
    private Vector2 myDirection = Vector2.right;
    public void Init(Vector2 g_direction)
    {
        myDirection = g_direction;
    }
    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }
    void Update()
    {
        rig.velocity = myDirection * mySpeed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Destroy(this.gameObject);
        }
    }
}
