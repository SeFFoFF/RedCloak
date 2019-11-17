using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour {

    public GameObject door1;
    public Sprite sTurnOn, sTurnOff;
    private bool triggerEntered = false;

    private void Update()
    {
        // Переключатель вкл
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            FindObjectOfType<AudioManager>().Play("openDoor");
            gameObject.GetComponent<SpriteRenderer>().sprite = sTurnOn;
            door1.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            triggerEntered = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            triggerEntered = false;
        }
    }
}
