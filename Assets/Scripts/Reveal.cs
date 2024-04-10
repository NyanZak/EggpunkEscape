using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reveal : MonoBehaviour
{
    public SpriteRenderer Rend;
    public Transform Parent;

    public float speed;
    public bool startIncreasing = false;
    public bool activated = false;
    public Color startColor;
    public Color endColor;
    public AudioSource SFX;
    public AudioClip revealNoise;

    private void Start()
    {
        Rend = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (startIncreasing)
        {
            IncreaseColor();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Egg" && !activated)
        {
            SFX.PlayOneShot(revealNoise);
            Rend.enabled = true;
            activated = true;
            gameObject.layer = 8;

            speed = 0.0025f;
            startIncreasing = true;

            for (int i = 0; i < Parent.childCount; i++)
            {
                Parent.GetChild(i).gameObject.SetActive(true);
            }
        }
        else if (col.gameObject.tag != "Egg")
        {
            startIncreasing = false;
            activated = false;
        }
    }

    private void IncreaseColor()
    {
        if (startIncreasing)
        {
            float t = (speed += Time.deltaTime);
            GetComponent<SpriteRenderer>().material.color = Color.Lerp(startColor, endColor, t);

            for (int i = 0; i < Parent.childCount; i++)
            {
                Parent.GetChild(i).GetComponent<SpriteRenderer>().material.color = Color.Lerp(startColor, endColor, t);
            }
        }

        else if (!startIncreasing)
        {
            speed = 0;
        }
    }
}
