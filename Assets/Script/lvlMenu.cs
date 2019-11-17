using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlMenu : MonoBehaviour {

    public void prologue()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        Debug.Log("Prologue is loaded");
        SceneManager.LoadScene(3);
    }

    public void chapter1()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        Debug.Log("Chapter 1 is loaded");
        SceneManager.LoadScene(4);
    }

    public void chapter2()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        Debug.Log("Chapter 2 is loaded");
        SceneManager.LoadScene(5);
    }

    public void chapter3()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        Debug.Log("Chapter 3 is loaded");
    }

    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("buttonClick");
        SceneManager.LoadScene(0);
    }
}
