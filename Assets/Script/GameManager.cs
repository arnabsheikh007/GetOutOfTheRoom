using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;
    private bool isLevelUp = false;
    private bool rightKeyCollected = false;
    private int currnetLevel = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager created and marked DontDestroyOnLoad.");
        }
        else if (Instance != this)
        {
            Debug.Log("Duplicate GameManager detected and destroyed.");
            Destroy(gameObject);
        }
    }

    public void Reset()
    {
        isGameOver = false;
        isLevelUp = false;
        rightKeyCollected = false;
    }


    public void LevelUp()
    {
        isLevelUp = true;
        ChangeSceneAfterDelay(0, 5f);
    }
    public bool IsLevelUp()
    {
        return isLevelUp;
    }

    public void GameOver()
    {
        isGameOver = true;
        ChangeSceneAfterDelay(0, 5f);
    }
    public void RightKeyCollected()
    {
        rightKeyCollected = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsRightKeyCollected()
    {
        return rightKeyCollected;
    }


    public void ChangeSceneAfterDelay(int sceneIndex, float delay)
    {
        Debug.Log("ChangeSceneAfterDelay called with scene: " + sceneIndex + " and delay: " + delay);
        StartCoroutine(ChangeSceneAfterDelayCoroutine(sceneIndex, delay));
    }

    private IEnumerator ChangeSceneAfterDelayCoroutine(int sceneIndex, float delay)
    {
        Debug.Log("Starting coroutine, will wait for " + delay + " seconds.");
        yield return new WaitForSeconds(delay);
        Debug.Log("Time elapsed, loading scene: " + sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

    public int GetCurrentLevel()
    {
        return currnetLevel;
    }
    public void SetCurrentLevel(int level)
    {
        currnetLevel = level;
    }
}
