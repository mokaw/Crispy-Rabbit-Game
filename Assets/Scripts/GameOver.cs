using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject[] GameOverScreenText;

    private int number ;
    public void Start()
    {
        // Setzt erstmal alle Game-Over Bilder auf false, sodass diese nicht angezeigt werden

        foreach (GameObject screen in GameOverScreenText)
        {
            screen.SetActive(false);
        }

        // ein zufälliges Bild wird im Spiel angezeigt

        number = Random.Range(0, GameOverScreenText.Length);
        GameOverScreenText[number].SetActive(true);
    }
    public void Setup ()
    {
        // GameOver-Text und Buttons werden angezigt
        gameObject.SetActive(true);
        
    }


    public void RestartButton()
    {
        //Beim klicken des Restart Buttons wird  die aktuelle Szene neu geladen 
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButton()
    {
        // Beim Klicken des Menü-Buttons wird zur Startszene gewechselt
        SceneManager.LoadScene("StartScreen");
    }
 

}
