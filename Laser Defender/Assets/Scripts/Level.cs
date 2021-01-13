using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 2f;
    [SerializeField] float kesleltetes = 2.5f;
    AudioClip kispirics;
    [SerializeField] [Range(0, 1)] float kispiricsVolume = 0.75f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayKispirics()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            AudioSource.PlayClipAtPoint(kispirics, Camera.main.transform.position, kispiricsVolume);
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }


public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
       SceneManager.LoadScene("Game Over");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR

        // Application.Quit() does not work in the editor so

        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game

        UnityEditor.EditorApplication.isPlaying = false;

    #else

         Application.Quit();

    #endif
 
    }

}
