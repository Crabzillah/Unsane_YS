using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip newTrack;
    private bool startButtonPressed = false;

    public float playTransitionTime;
    // Start is called before the first frame update
    public void PlayGame()
    {
        startButtonPressed = true;
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
        AudioManager.instance.ReturnToDefault();
    }

    private void Update()
    {
        if(startButtonPressed)
        {
            StartCoroutine(StartRoutine());
        }
    }
    IEnumerator StartRoutine()
    {
        yield return new WaitForSeconds(playTransitionTime);
        SceneManager.LoadScene(1); // <----------- ADDED INDEX (2) INSTEAD IF (1)

    }
}
