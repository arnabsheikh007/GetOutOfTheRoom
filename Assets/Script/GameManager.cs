using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
