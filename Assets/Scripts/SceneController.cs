using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Game_Manager Manager;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    //private void Update()
    //{
    //    if (Manager.p1 > 4 || Manager.p2 > 4) ;
    //    { 
    //        SceneManager.LoadScene(0); 
    //    }

    //}
    public void ExitGame()
    {
        Application.Quit();
    }
}