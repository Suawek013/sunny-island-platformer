using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject[] heart;
    private int hp = 2;
       private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "void") {
            hp=-1;
            SceneManager.LoadScene("Lose");
        }
        if(collision.tag == "Enemy") {
            if(hp <0) {
                SceneManager.LoadScene("Lose");
            } else {
                heart[hp].SetActive(false);
                hp--;
                 if(hp <0) {
                SceneManager.LoadScene("Lose");
                 }
            }
        }
        if(collision.tag == "Potion") {
            if(hp==2)
            {
                return;
            }
            collision.gameObject.SetActive(false);
            hp++;
            for(int i=0;i<=hp;i++)
            {
                heart[i].SetActive(true);
            }

        }
    }
}
