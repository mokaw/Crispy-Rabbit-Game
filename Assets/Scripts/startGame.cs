using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject instruction;
    public void startButton()
    {
        // Starte Spiel, wenn Button gedrückt wurde
        SceneManager.LoadScene("SampleScene");
    }

    public void showInstuction()
    {
        // Blene die Anleitung ein, wenn Button gedrückt wurde
        instruction.SetActive(true);
    }

    public void closeInstuction()
    {   
        // Blende Anleitung-Objekt aus, wenn Button gedrückt wurde
        instruction.SetActive(false);
    }

    public void showHighscore()
    {
        //Starte HighscoreSzene, wenn Button gedrückt wurde
        SceneManager.LoadScene("Highscore");
    }
}
