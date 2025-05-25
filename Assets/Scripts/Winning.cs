using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Winning : MonoBehaviour
{
    public GameObject[] WinningScreenText;
   
    private int number;
    private int score;

    public Text scoreText;

    public void Start()
    {
        

        foreach (GameObject screen in WinningScreenText)
        {
            screen.SetActive(false);
        }


        number = UnityEngine.Random.Range(0, WinningScreenText.Length);
        WinningScreenText[number].SetActive(true);

    }
    public void Setup(int distance)
    {
        gameObject.SetActive(true);
        score = distance;

        scoreText.text = "Dein Score: " + score;
        Highscore.AddHighscoreEntry(score);



    }
    public void MenuButton()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void HighscoreButton()
    {
        SceneManager.LoadScene("Highscore");
    }


}
