using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour 
{
	public GameObject gameOverText;
	public Text ScoreText;
	public static GameControl instance;
	public bool gameOver = false;
	public float scrollSpeed = -1.5f;
	private int score = 0;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void Update()
	{
		if (gameOver == true && Input.GetMouseButtonDown (0)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	public void birdScore()
	{
		if (gameOver) 
		{
			return;
		}
		score++;
		ScoreText.text = "Score: " + score.ToString();
	}

	public void birdDied()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}
}