using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused; //can make static and fix further bugs
    public GameObject player;
    private StarterAssets.StarterAssetsInputs inputs;
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
            if(inputs = null)
            {
                CheckForInputs();
            }
            if(isPaused)
            {
                ResumeGame();
                
            }
            else
            {
                PauseGame();

            }
        }
    }

    public void PauseGame()
    {
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        inputs.LookInput(Vector2.zero);
        inputs.MoveInput(Vector2.zero);



    }

    public void ResumeGame()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputs.LookInput(Vector2.zero);
        inputs.MoveInput(Vector2.zero);

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

    void CheckForInputs()
    {
        try
        { inputs = player.GetComponent<StarterAssets.StarterAssetsInputs>(); }
        catch
        {
            Debug.Log("CAN'T Find INPUTS YET");
        }
        
    }
}
