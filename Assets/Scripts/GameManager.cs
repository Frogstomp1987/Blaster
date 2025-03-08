using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;


    [SerializeField]
    GameObject pressAnyKeyPanel, gameOverPanel, gameWonPanel;

    Rigidbody2D ball;

    bool gameStarted = false, gameOver = false;

    int spawnedBricks = 0;

    private void Awake()
    {
        gameManager = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetGameScene();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            gameOverPanel.SetActive(false);
            gameWonPanel.SetActive(false);
            ResetGameScene();
        }
        else if (!gameStarted && Input.GetMouseButtonDown(0))
        {
            gameStarted = true;
            pressAnyKeyPanel.SetActive(false);
            ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
            ball.AddForce(Vector2.up);
        }
    }

    void ResetGameScene()
    {
        if (SceneManager.GetSceneByName("GameScene").name == "GameScene")
        {
            SceneManager.UnloadScene("GameScene");
        }

        SceneManager.LoadScene("GameScene",LoadSceneMode.Additive);
        gameOver = false;
        gameStarted = false;
        spawnedBricks = 0;
    }


    public void GameOver()
    {
        Console.WriteLine("Metodo GameOver");
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void GameWon()
    {
        Console.WriteLine("Metodo GameWon");
        Destroy(ball.gameObject);
        gameWonPanel.SetActive(true);
        gameOver = true;
    }

    public void SetSpawnedBricks(int value)
    {
        Console.WriteLine("Brick spawnati: " + value);
        spawnedBricks = value;
    }

    public void BrickDestroyed()
    {
        spawnedBricks--;
        if(spawnedBricks <= 0)
        {
            Console.WriteLine("Hai vinsto, brick distrutti: " + spawnedBricks);
            GameWon();
        }
    }

}
