using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAUSEMENU : MonoBehaviour
{
 
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject PauseMenuUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused )
            {
                Resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false ;

    }
    public void pause() 
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }



    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("loading");
    }


    public void QuitGame()
    {
        Debug.Log("Quitgame");
        Application.Quit();
    }
}
