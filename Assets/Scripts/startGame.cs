using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject instruction;
    public void startButton()
    {
        // Starte Spiel, wenn Button gedr�ckt wurde
        SceneManager.LoadScene("SampleScene");
    }

    public void showInstuction()
    {
        // Blene die Anleitung ein, wenn Button gedr�ckt wurde
        instruction.SetActive(true);
    }

    public void closeInstuction()
    {   
        // Blende Anleitung-Objekt aus, wenn Button gedr�ckt wurde
        instruction.SetActive(false);
    }

    public void showHighscore()
    {
        //Starte HighscoreSzene, wenn Button gedr�ckt wurde
        SceneManager.LoadScene("Highscore");
    }
}
