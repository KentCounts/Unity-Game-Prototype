using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;

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

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
        }
    }

    public void ResumeGame()
    {
        if (isPaused)
        {
            TogglePause();
        }
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();

        Debug.Log("Quit Game");
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}