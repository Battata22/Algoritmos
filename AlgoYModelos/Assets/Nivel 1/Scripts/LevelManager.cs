using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
