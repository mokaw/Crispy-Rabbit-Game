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

    private void Awake()
    {
        entryTemplate.gameObject.SetActive(false);


        // Lade gespeicherte Highscores aus PlayerPrefs
        string jsonString = PlayerPrefs.GetString("highscoreTable"); 
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        //HighScore Liste wird sortiert --> niedrigster Score an erster Stelle
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

        // Wenn die Liste grrößer als 10 ist, lade nur die ersten 10 in highscoreEntryList
        if(highscores.highscoreEntryList.Count > 10)
        {
            highscores.highscoreEntryList = highscores.highscoreEntryList.GetRange(0, 10);
        }

         // Erstelle und zeige die Highscore Liste in UI an
        highscoreEntryTransformList = new List<Transform>();
       
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

 
    }
    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
        {
            float templateHeight = 50f;

            // erstellt eine Kopie des Templates im Container
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            
            // positioniert das neue UI-Feld und zeig es an 
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            // Setzte das Textfeld "rankNumber" auf die Rangnummer
            int rank = transformList.Count + 1;
            string rankString = rank + ".";
            entryTransform.Find("rankNumber").GetComponent<Text>().text = rankString;
            
            // Setzte den Punktestand
            int score = highscoreEntry.score;

            entryTransform.Find("score").GetComponent<Text>().text = score.ToString();

        // Eintrag wird der highscoreEntryTransformList hinzugefügt
        transformList.Add(entryTransform);
        }


    public static void AddHighscoreEntry(int score)
    {
        // Neuer Highscore Eintrage wird erstellt
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };

        // bestehende Highscores werden geladen
        string jsonString = PlayerPrefs.GetString("highscoreTable");

        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Initialsiere Liste, falls sie leer ist
        if (highscores == null)
        {
            highscores = new Highscores();
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }
        else if (highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }

        // Füge neuen Eintrage hinzu
        highscores.highscoreEntryList.Add(highscoreEntry);


        // Speicher aktualisierte List in PlayerPrefs
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }


    // Klasse mit gesammter Highscore Liste
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    // Ein einzelner Highscore Einrag
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
    }

    // Wird MenüButton gedrückt, wird zur startszene gewechselt
    public void startMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

}
