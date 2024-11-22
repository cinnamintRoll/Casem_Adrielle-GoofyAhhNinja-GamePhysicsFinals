using UnityEngine;
using UnityEngine.SceneManagement;

public class OtherButtons : MonoBehaviour
{
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectsWithTag("Audio")[0].GetComponent<AudioManager>();
    }

    public void ExitGame()
    {
        Debug.Log("Exit was clicked");
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}