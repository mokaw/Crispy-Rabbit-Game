using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public GameObject[] WinningScreenText;

    private int number;

    public void Start()
    {
        foreach (GameObject screen in WinningScreenText)
        {
            screen.SetActive(false);
        }


        number = Random.Range(0, WinningScreenText.Length);
        WinningScreenText[number].SetActive(true);
    }
    public void Setup()
    {
        gameObject.SetActive(true);


    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
