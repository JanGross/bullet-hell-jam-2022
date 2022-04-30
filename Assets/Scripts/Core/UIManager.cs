using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI playerHealthLabel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI waveLabel;

    public GameObject healthContainer;
    
    public Image healthBar;

    public Button restartButton;
    public Button scoreboardButton;
    private  GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, gameManager.player.health * 3);
        //round player health 
        playerHealthLabel.text = "Health: " + Mathf.Round(gameManager.player.health).ToString();

        scoreLabel.text = "Score: " + Mathf.Round(gameManager.score).ToString();

        waveLabel.text = "Wave: " + (gameManager.overallWave + 1).ToString();

        if (gameManager.player.health <= 0)
        {
            Debug.Log("Game Over");
            gameOverPanel.SetActive(true);
            restartButton.gameObject.SetActive(true);
            scoreboardButton.gameObject.SetActive(true);
        }

        if (gameManager.player.health <= 15)
        {
            //play animation on healthContainer
            healthContainer.GetComponent<Animation>().Play();
            
            
        }
    }
}
