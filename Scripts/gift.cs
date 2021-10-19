using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gift : MonoBehaviour
{
    [SerializeField] GameObject ThankPrefab;
    [SerializeField] GameObject Pos;
    
    private void Start()
    {
        Pos = GameObject.Find("thank");
    }
    private void OnMouseDown()
    {
        GameObject ThankYou = Instantiate(ThankPrefab);
        ThankYou.transform.parent = Pos.transform;
        ThankYou.transform.localPosition = new Vector3(0, -1, 0);
        Time.timeScale = 0;
    }
}
