using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
   public void Play() {
        SceneManager.LoadScene("Game");
   }

   public void Quit() {
        Application.Quit();
   }
}
