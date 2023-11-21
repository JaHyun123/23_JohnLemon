using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public enum GameState
	{
		MainMenu,
		GameStart,
		GamePaused,
		GameEnd
	}

	public GameState gameState;

	public TMP_Text timerText;
	public TMP_Text NameText;

	public InputField playerNameInput;
	private string playerName = null;

	private float _timer;

	public GameObject player;

	private float TimeScore;
	private float BestTime;
	private int CoinScore;
	public TMP_Text TimeScoreText;
	public TMP_Text CoinScoreText;
	public TMP_Text BestScoreText;
	public TMP_Text BestTimeText;

	private int bestScore = 0;


	public void GameStart()
	{
		SceneManager.LoadScene("MainScene");
		gameState = GameState.GameStart;
	}
	public void GameRanking()
	{
		SceneManager.LoadScene("RankingScene");
		gameState = GameState.GamePaused;
	}
	public void GameClear()
	{
		PlayerPrefs.SetFloat("TS", _timer);
		PlayerPrefs.SetInt("CS", Score.coinAmount);
		if (Score.coinAmount > bestScore)
		{
			PlayerPrefs.SetInt("BS", Score.coinAmount);
			PlayerPrefs.SetFloat("BC", _timer);
		}
		SceneManager.LoadScene("RankingScene");
		gameState = GameState.GamePaused;
	}

	public void GameMenu()
	{
		SceneManager.LoadScene("MenuScene");
		gameState = GameState.MainMenu;
	}

	public void GameExit()
	{
		UnityEngine.Application.Quit();
		gameState = GameState.GameEnd;
	}



private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}


	void Start()
	{
        
    }
	// Update is called once per frame
	void Update()
	{
		if (gameState == GameState.MainMenu)
		{
         
        }
		else if (gameState == GameState.GameStart)
		{
          
            if (timerText == null)
				timerText = GameObject.Find("Timer").GetComponent<TMP_Text>();
			_timer = _timer + Time.deltaTime;
			timerText.text = _timer.ToString("N2");
		}
		else if (gameState == GameState.GamePaused)
		{
  

            TimeScore = PlayerPrefs.GetFloat("TS") - 5f;

			CoinScore = PlayerPrefs.GetInt("CS");
			if (TimeScoreText == null)
				TimeScoreText = GameObject.Find("TimeScore").GetComponent<TMP_Text>();
			TimeScoreText.text = TimeScore.ToString("N2");

			if (CoinScoreText == null)
				CoinScoreText = GameObject.Find("CoinScore").GetComponent<TMP_Text>();
			CoinScoreText.text = CoinScore.ToString();

			bestScore = PlayerPrefs.GetInt("BS");
			if (BestScoreText == null)
				BestScoreText = GameObject.Find("BestCoin").GetComponent<TMP_Text>();
			BestScoreText.text = bestScore.ToString();

			BestTime = PlayerPrefs.GetFloat("BC") - 5f;
			if (BestTimeText == null)
				BestTimeText = GameObject.Find("Besttime").GetComponent<TMP_Text>();
			BestTimeText.text = BestTime.ToString("N2");
		}
        else if (gameState == GameState.GameEnd)
        {

        }
    }
}


