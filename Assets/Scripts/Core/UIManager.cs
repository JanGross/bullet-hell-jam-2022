using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHealthLabel;
    public TextMeshProUGUI gameOverLabel;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI waveLabel;

    public Button restartButton;
    private  GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //round player health 
        playerHealthLabel.text = "Health: " + Mathf.Round(gameManager.player.health).ToString();

        scoreLabel.text = "Score: " + Mathf.Round(gameManager.score).ToString();

        waveLabel.text = "Wave: " + (gameManager.wave + 1).ToString();

        if (gameManager.player.health <= 0)
        {
            gameOverLabel.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
    }
}
