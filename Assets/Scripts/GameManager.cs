using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    [SerializeField] private GameObject endGameSplash;

    private bool playerActive = true;
    private bool gameOver = false;
    private bool gameStarted = true;
    private bool gameEnded = false;

    private int coinCollected = 0;

    public bool PlayerActive
    {
        get { return playerActive; }
    }

    public bool GameOver
    {
        get  { return gameOver; }
    }

    public bool GameStarted
    {
        get { return gameStarted;  }
    }

    public bool GameEnded
    {
        get { return gameEnded;  }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void PlayerCollided()
    {
        gameOver = true;
        endGameSplash.SetActive(true);
    }

    public void PlayerStartedGame()
    {
        playerActive = true;
        endGameSplash.SetActive(false);
    }

    public void EnteredGame()
    {
        gameStarted = true;
    }

    public void CoinCollected()
    {
        coinCollected++;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
