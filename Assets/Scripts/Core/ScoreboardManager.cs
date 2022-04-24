using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    public string username;
    public Button btnSubmit;
    public TMPro.TextMeshProUGUI currentScore;

    [Header("Global Scores")]
    public TMPro.TextMeshProUGUI globalNames;
    public TMPro.TextMeshProUGUI globalScores;

    private int playerScore = 0;
    private bool submitted = false;

    [System.Serializable]
    public class Score
    {
        public string username;
        public int score;
    }
    [System.Serializable]
    public class Scores
    {
        public Score[] scores;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetScores());
        //find gamemanager
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        //set current score
        currentScore.text = gm.score.ToString();
        playerScore = gm.score;
    }

    // Update is called once per frame
    void Update()
    {
        btnSubmit.interactable = username.Length > 0 && !submitted;
    }

    public void UpdateUsername(string _username)
    {
        username = _username;
    }

    public void SubmitScore()
    {
        btnSubmit.interactable = false;
        StartCoroutine(SendScoreToServer());
    }

    IEnumerator SendScoreToServer()
    {
        string additional_data = "{}";
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("score", playerScore);
        form.AddField("additional_data", additional_data);
        using (UnityWebRequest www = UnityWebRequest.Post("http://vps5.minzkraut.com:3030/scores", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                btnSubmit.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Error :(";
            }
            else
            {
                Debug.Log("Score submitted");
                btnSubmit.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Submitted!";
                submitted = true;
                StartCoroutine(GetScores());
            }
        }
    }
    
    IEnumerator GetScores()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://vps5.minzkraut.com:3030/scores"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            globalNames.text = "";
            globalScores.text = "";

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    globalNames.text = "Error: " + webRequest.error;
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    globalNames.text = "Error: " + webRequest.error;
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Received: " + webRequest.downloadHandler.text);
                    Scores scores = JsonUtility.FromJson<Scores>("{\"scores\":" + webRequest.downloadHandler.text + "}");
                   
                    foreach (Score score in scores.scores)
                    {
                        globalNames.text += score.username + "\n";
                        globalScores.text += score.score + "\n";
                        Debug.Log(score.username + ": " + score.score);
                    }
                    break;
            }
        }
    }
}
