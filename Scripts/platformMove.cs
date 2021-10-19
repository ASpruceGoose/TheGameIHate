using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    [SerializeField] Transform[] myWayPoints;
    [SerializeField] float mySpeed;
    private int myIndex;
    private float myProgress;
    private void Start()
    {
        myIndex = 0;
        myProgress = 0;
    }
    private void Update()
    {
        this.transform.position = Vector2.Lerp(myWayPoints[myIndex].position, myWayPoints[GetNextIndex(myIndex)].position, myProgress);
        myProgress += Time.deltaTime * mySpeed;
        if(myProgress>=1)
        {
            myIndex = GetNextIndex(myIndex);
            myProgress = 0;
        }
    }
    private int GetNextIndex(int g_index)
    {
        g_index += 1;
        if(g_index>=myWayPoints.Length)
        {
            g_index -= myWayPoints.Length;
        }
        return g_index;
    }
}
