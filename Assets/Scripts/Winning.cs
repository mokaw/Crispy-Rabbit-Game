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


        number = Random.Range(0, WinningScreenText.Length);
        WinningScreenText[number].SetActive(true);

    }
    public void Setup(int distance)
    {
        gameObject.SetActive(true);
        score = distance;
      

       /* for(int i= 0; i < 10; i++)
        {  Debug.Log("highscore List " +Highscore.highscoreList[i]);
            if (score > Highscore.highscoreList[i])
                    {
                        Highscore.AddHighscoreEntry(score);
                        scoreText.text = "Neuer Highscore: " + score.ToString();
                    }
                    else
                    {
                        scoreText.text = "Dein Score:" + score.ToString();
                    }
        } */
   
        


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
