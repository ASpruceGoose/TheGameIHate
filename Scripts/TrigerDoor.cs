using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerDoor : MonoBehaviour
{
    [SerializeField] string myTargetSceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")//if(collision.gameObject.name="player")或者if(collision.GetComponent<playerMovement>()==true)
        {
            Debug.Log("it collided with" + collision.name);
            //SceneManager.LoadScene("Game2");
            SceneManager.LoadScene(myTargetSceneName);
            Destroy(this.gameObject);
        }
    }
}
