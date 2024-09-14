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
        if(GameManager.Instance.IsLevelUp())
        {
            Debug.Log("Level Up");
            LoadLevelUpPanel();

        }
        if (GameManager.Instance.IsGameOver())
        {
            Debug.Log("Game Over");
            LoadGameOverPanel();
        }
    }

    public void NewGame()
    {
       SceneManager.LoadScene(1);
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

}
