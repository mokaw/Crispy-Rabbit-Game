using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Highscore : MonoBehaviour
{
    public  Transform entryContainer;
    public  Transform entryTemplate;
    private  List<Transform> highscoreEntryTransformList;

    public  int[] highscoreList= new int[10];

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for ( int i  = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for(int j= i+1; j< highscores.highscoreEntryList.Count; j++)
            {
                if(highscores.highscoreEntryList[j].score < highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        if(highscores.highscoreEntryList.Count > 10)
        {
            highscores.highscoreEntryList = highscores.highscoreEntryList.GetRange(0, 10);
        }

        for(int i= 0; i< 10; i++)
        {
            if (i < highscores.highscoreEntryList.Count && highscores.highscoreEntryList[i] != null)
            {
                highscoreList[i] = highscores.highscoreEntryList[i].score;
            }
            else
            {
                highscoreList[i] = 0; 
            }

        }

        highscoreEntryTransformList = new List<Transform>();

        foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

 
    }
    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
        {
            float templateHeight = 50f;
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);

            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString = rank + ".";
            entryTransform.Find("rankNumber").GetComponent<Text>().text = rankString;

            int score = highscoreEntry.score;

            entryTransform.Find("score").GetComponent<Text>().text = score.ToString();

            transformList.Add(entryTransform);
        }


    public static void AddHighscoreEntry(int score)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

    public void startMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

}
