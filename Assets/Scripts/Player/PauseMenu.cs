using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioSource pauseFx;
    public AudioClip pauseMenuSound;
    public GameObject pauseMenu;
    public GameObject inventoryUI;
    public static bool isPaused; //can make static and fix further bugs
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (inventoryUI.activeSelf == true)
            {
                PlayPauseSound();
                
                inventoryUI.SetActive(false);
                Inventory.instance.inventoryActive = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                PlayPauseSound();
                if (isPaused)
                {
                    ResumeGame();

                }
                else
                {
                    PauseGame();

                }
            }

        }


    }

    public void PauseGame()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        



    }

    public void ResumeGame()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;



    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayPauseSound()
    {
        pauseFx.volume = 0.5f;
        pauseFx.PlayOneShot(pauseMenuSound);
    }


}
