using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject levelUpPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWonPanel;
    [SerializeField] private GameObject mainMenuPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            Debug.Log("Game Over");
            LoadGameOverPanel();
        }
        else if(GameManager.Instance.IsLevelUp())
        {
            if(GameManager.Instance.GetCurrentLevel() == 2)
            {
                LoadGameWonPanel();
            }
            else
            {
                LoadLevelUpPanel();
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void nextLevel()
    {
        int nextLevel = GameManager.Instance.GetCurrentLevel() + 1;
        GameManager.Instance.SetCurrentLevel(nextLevel);
        GameManager.Instance.Reset();
        SceneManager.LoadScene(nextLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevelUpPanel()
    {
        mainMenuPanel.SetActive(false);
        levelUpPanel.SetActive(true);
    }

    public void LoadGameOverPanel()
    {
        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void LoadGameWonPanel()
    {
        mainMenuPanel.SetActive(false);
        gameWonPanel.SetActive(true);
    }

    public void LoadMainMenuPanel()
    {
        GameManager.Instance.Reset();
        levelUpPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameWonPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void RestartGame()
    {
        int currentLevel = GameManager.Instance.GetCurrentLevel();
        GameManager.Instance.Reset();
        SceneManager.LoadScene(currentLevel);
    }

}
