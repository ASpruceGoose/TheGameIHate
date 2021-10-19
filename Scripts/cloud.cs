using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private float speed = 0.5f;
    [SerializeField] Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity =new Vector2(speed,0);
    }
}
