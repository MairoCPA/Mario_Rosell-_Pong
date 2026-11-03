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
    public void ExitGame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (Manager.p1 >= 5)
        { 
            SceneManager.LoadScene(1); 
        }
        if (Manager.p2 >= 5)
        {
            SceneManager.LoadScene(1);
        }
    }
}