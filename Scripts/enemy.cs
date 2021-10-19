using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject hurtPrefab;
    public int enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth<=0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            GameObject hurtsprite = Instantiate(hurtPrefab);
            hurtsprite.transform.parent = this.transform;
            hurtsprite.transform.localPosition = new Vector3(0f, 0.75f, 0);
            Destroy(hurtsprite, 0.2f);
            enemyHealth--;
        }
    }
}
