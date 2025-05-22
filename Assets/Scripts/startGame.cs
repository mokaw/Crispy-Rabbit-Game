using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public GameObject instruction;
    public void startButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void showInstuction()
    {
        instruction.SetActive(true);
    }

    public void closeInstuction()
    {
        instruction.SetActive(false);
    }
}
