using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip newTrack;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // <----------- ADDED INDEX (2) INSTEAD IF (1)
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartButtonPress()
    {
        AudioManager.instance.SwapTrack(newTrack);
    }

    public void BackToStartMenu()
    {
        AudioManager.instance.IsBackToStart();
    }
}
