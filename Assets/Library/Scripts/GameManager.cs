using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private float spawnRate = 1.0f;
    [SerializeField] private UnityEngine.UI.Button restartButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject menuBackground;
    [SerializeField] private GameObject gameBackground;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float timeRemaining = 60f;

    private int score;
    public bool isGameActive;
    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    public void UpdateTime(float timeRemaining)
    {
        timeText.text = "Time Left: " + timeRemaining;
    }

    IEnumerator SpawnTarget()
    {
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        finalScoreText.text = "Final Score: " + score;
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void StartGame(int difficulty)
    {
        ChangeMusic();

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        StartCoroutine(StartCountdown());

        menuBackground.gameObject.SetActive(false);
        gameBackground.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    public void ChangeMusic()
    {
        audioManager.musicSource.loop = false;
        audioManager.musicSource.clip = audioManager.gameBackground;
        audioManager.musicSource.Play();
    }

    // Countdown timer
    IEnumerator StartCountdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            UpdateTime(timeRemaining);

            if (timeRemaining <= 0)
            {
                GameOver();
            }
        }
    }
}
