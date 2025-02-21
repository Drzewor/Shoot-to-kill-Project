using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject gameMenuGameObject;

    private void Start() 
    {
        Time.timeScale = 1;
        gameMenuGameObject.SetActive(false);
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameMenuGameObject.activeSelf)
            {
                Time.timeScale = 1;
                gameMenuGameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                gameMenuGameObject.SetActive(true);
            }
        }
    }


    public void RelodeGame()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
