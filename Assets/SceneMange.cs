using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMange : MonoBehaviour
{
    public void StartWoz()
    {
        SceneManager.LoadScene(1);
    }
    
    public void MovetoendWoz()
    {
        SceneManager.LoadScene(2);
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
