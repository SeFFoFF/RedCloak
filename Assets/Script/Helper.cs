using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour {

    public GameObject adMoveUI, adJumpUI, adAttackUI, switchUI;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "adMove")
        {
            adMoveUI.SetActive(true);
        }

        if (collider.gameObject.tag == "adJump")
        {
            adJumpUI.SetActive(true);
        }

        if (collider.gameObject.tag == "adAttack")
        {
            adAttackUI.SetActive(true);
        }

        if (collider.gameObject.tag == "adSwitch")
        {
            switchUI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "adMove")
        {
            adMoveUI.SetActive(false);
        }

        if (collision.gameObject.tag == "adJump")
        {
            adJumpUI.SetActive(false);
        }

        if (collision.gameObject.tag == "adAttack")
        {
            adAttackUI.SetActive(false);
        }

        if (collision.gameObject.tag == "adSwitch")
        {
            switchUI.SetActive(false);
        }
    }
}
