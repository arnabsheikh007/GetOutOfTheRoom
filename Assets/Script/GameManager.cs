using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isGameOver = false;
    private bool rightKeyCollected = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        isGameOver = true;
        ChangeSceneAfterDelay(1, 5f);
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
}
