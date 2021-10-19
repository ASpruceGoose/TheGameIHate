using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    public GameObject player;
    void Update()
    {
        //this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
        Vector3 t_newPos = player.transform.position;
        t_newPos.z = -10;
        this.transform.position =Vector3.Lerp(this.transform.position,t_newPos,Time.deltaTime*10);//Lerp(A,B,百分比）在AB间取值，比例是百分比

    }
}
