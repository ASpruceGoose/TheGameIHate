using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALL : MonoBehaviour
{
    [SerializeField] float mySpeed;
    [SerializeField] Rigidbody2D rig;
    [SerializeField] GameObject ballPos;
    [SerializeField] GameObject BallPrefab;
    private Vector2 myDirection = Vector2.right;
    private void Start()
    {
        ballPos = GameObject.Find("BallPosition");
        Destroy(this.gameObject, 2f);

    }

    public void Init(Vector2 g_direction)
    {
        myDirection = g_direction;
    }
    void Update()
    {
        rig.velocity = myDirection * mySpeed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pokemon")
        {
            collision.gameObject.SetActive(false);
            GameObject GetPokemonBall=Instantiate(BallPrefab);
            GetPokemonBall.transform.parent = ballPos.transform;
            GetPokemonBall.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(this.gameObject);
        }
    }
}
