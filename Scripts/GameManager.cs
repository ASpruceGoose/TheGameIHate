using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Text_Die;
    [SerializeField] GameObject[] healthNum;
    private void Start()
    {
        Text_Die.SetActive(false);
    }
    private void Update()
    {
        CheckHealth();
        if (Input.GetKey(KeyCode.R)|| Input.GetKey(KeyCode.F4))
        {
            Time.timeScale = 1;
            //SceneManager.LoadScene("Game");与下面的等价
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);//直接获取当前active的场景的名字
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void CheckHealth()
    {
        if (GameObject.Find("player").GetComponent<playerMovement>().health<=0)
        {
            Time.timeScale = 0;

            Text_Die.SetActive(true);
        }
    }
}
