using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject coinSprite;
    [SerializeField] private float maxCoinDistance = 5f;
    [SerializeField] private float waitTime = 10f;
    
    // Game text control
    [SerializeField] private TextMeshProUGUI scoreText;
    private string prefix = "score: ";
    private int score;
    
    // End Game
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private Button restartButton;
    private bool shouldSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(SpawnCoins());
    }

    private void UpdateTextLabel()
    {
        scoreText.text = prefix + score;
    }

    public void IncrementScore()
    {
        score++;
        UpdateTextLabel();
    }

    public void EndGame()
    {
        endText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        shouldSpawn = false;
    }
    
    private void SpawnCoin()
    {
        var position = new Vector2(Random.Range(-maxCoinDistance, maxCoinDistance),Random.Range(-maxCoinDistance, maxCoinDistance));
        Instantiate(coinSprite, position, Quaternion.identity);
        
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (!shouldSpawn) break;
            SpawnCoin();
            //IncrementScore();
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
