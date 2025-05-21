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
        foreach (GameObject screen in GameOverScreenText)
        {
            screen.SetActive(false);
        }


        number = Random.Range(0, GameOverScreenText.Length);
        GameOverScreenText[number].SetActive(true);
    }
    public void Setup ()
    {
        gameObject.SetActive(true);
        
        
    }


    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
 

}
