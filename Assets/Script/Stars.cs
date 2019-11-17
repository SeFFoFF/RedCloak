using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour {

    public int stars = 0;
    public int star = 0;
    public int numOfStars = 3;

    public Image[] starImg;
    public Sprite fullStar;
    public Sprite emptyStar;

    public GameObject pickStarEffect;

    private void Update()
    {
        if (star > numOfStars)
            star = numOfStars;

        for (int i = 0; i < starImg.Length; i++)
        {
            if (i < star)
                starImg[i].sprite = fullStar;
            else
                starImg[i].sprite = emptyStar;


            if (i < numOfStars)
                starImg[i].enabled = true;
            else
                starImg[i].enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Star")
        {
            if (star != numOfStars)
            {
                FindObjectOfType<AudioManager>().Play("takeStar");
                StarEffect();
                star++;
                stars++;
            }
            Destroy(collision.gameObject);
        }
    }

    void StarEffect()
    {
        Instantiate(pickStarEffect, transform.position, Quaternion.identity);
    }
}
