using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalCountDown : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 60f;

    public float currentTime2 = 0f;
    public float startingTime2 = 30f;

    public float currentTime3 = 0f;
    public float startingTime3 = 20f;

    public float currentEggCount = 0;
    public float eggCount = 10;

    public bool PuzzleTimer1;
    public bool PuzzleTimer2;
    public bool PuzzleTimer3;
    public bool hasAddedEggs1;

    [SerializeField]
    Text countdownText;

    [SerializeField]
    Text eggCountdownText;

    private void Start()
    {
        hasAddedEggs1 = false;
        currentTime = startingTime;
        currentTime2 = startingTime2;
        currentTime3 = startingTime3;
        currentEggCount = eggCount;
        PuzzleTimer1 = true;
        PuzzleTimer2 = false;
        PuzzleTimer3 = false;
    }

    private void Update()
    {
        eggCountdownText.text = "Eggs Left: " + currentEggCount.ToString("0");

        if (currentEggCount <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            eggCount = 0f;
            currentEggCount = 0f;
        }

        if (PuzzleTimer1)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = "Time Left: " + currentTime.ToString("0");

            if (currentTime <= 0)
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                currentTime = 0;
            }
        }

        if (PuzzleTimer2)
        {
            currentTime2 -= 1 * Time.deltaTime;
            countdownText.text = "Time Left: " + currentTime2.ToString("0");

            if (currentTime2 <= 0)
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                currentTime2 = 0;
            }
        }

        if (PuzzleTimer3)
        {
            currentTime3 -= 1 * Time.deltaTime;
            countdownText.text = "Time Left: " + currentTime3.ToString("0");

            if (currentTime3 <= 0)
            {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                currentTime3 = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentEggCount -= 1f;
        }
    }
}

  
    


