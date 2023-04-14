using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void StartWoz()
    {
        SceneManager.LoadScene(1);
    }
    
    public void MovetoTask1()
    {
        SceneManager.LoadScene(2);
    }
    public void MovetoTask2()
    {
        SceneManager.LoadScene(3);
    }

    public void MovetoTask3()
    {
        SceneManager.LoadScene(4);
    }

    public void RestartWoz()
    {
        SceneManager.LoadScene(0);
    }

    public void EndWoz()
    {
        Application.Quit();
    }
}
