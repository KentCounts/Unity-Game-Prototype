using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseText;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        Time.timeScale = isPaused ? 0f : 1f;

        if (pauseText != null)
        {
            pauseText.SetActive(isPaused);
        }

        Debug.Log(isPaused ? "Game Paused" : "Game Resumed");
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}