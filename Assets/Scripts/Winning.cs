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
        
        // Winner-Bilder werden alle auf false gesetzt
        foreach (GameObject screen in WinningScreenText)
        {
            screen.SetActive(false);
        }

        // Zufälliges Bild wird ausgewählt und angezeigt
        number = UnityEngine.Random.Range(0, WinningScreenText.Length);
        WinningScreenText[number].SetActive(true);

    }
    public void Setup(int distance)
    {
        //Winner-Text wird angezeigt
        gameObject.SetActive(true);
        score = distance;

        scoreText.text = "Dein Score: " + score;

        //Distanz wird an AddHighscoreEntry-Methode übergeben
        Highscore.AddHighscoreEntry(score);



    }
    public void MenuButton()
    {
        //Szene wird neu geladen
        SceneManager.LoadScene("StartScreen");
    }

    public void HighscoreButton()
    {
        // Highscore-Szene wird geladen
        SceneManager.LoadScene("Highscore");
    }


}
