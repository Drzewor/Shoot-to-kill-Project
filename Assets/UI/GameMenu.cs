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
            int playerHealthPoints = FindObjectOfType<PlayerHealt>().GetplayerCurrentHP;

            if(playerHealthPoints <= 0) return;

            if(gameMenuGameObject.activeSelf)
            {
                Time.timeScale = 1;
                gameMenuGameObject.SetActive(false);
                FindObjectOfType<WeaponSwitcher>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                gameMenuGameObject.SetActive(true);
                FindObjectOfType<WeaponSwitcher>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
