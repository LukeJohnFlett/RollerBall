using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
   public MainMenu mainMenu;

   public void Open()
   {
      SceneManager.LoadScene(0);
   }

   public void Update()
   {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
         
         mainMenu.gameObject.SetActive(!mainMenu.gameObject.activeSelf);
      }
   }
}
