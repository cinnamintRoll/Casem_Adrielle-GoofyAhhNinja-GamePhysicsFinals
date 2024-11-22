using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    [SerializeField] private int difficulty;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetDifficulty()
    {
        audioManager.PlaySFX(audioManager.click);
        Debug.Log(button.gameObject.name + " was clicked");
        gameManager.StartGame(difficulty);
    }
}