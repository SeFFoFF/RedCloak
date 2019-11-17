using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	public void Play()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene(2);
    }

    public void Settings()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene(0);
    }
}
